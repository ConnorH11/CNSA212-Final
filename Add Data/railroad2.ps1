# Define SQL connection using your provided connection string
$connString = "Server=100.84.117.15;Database=FINAL;User Id=connor;Password=FinalJawn1;"
$sqlConnection = New-Object System.Data.SqlClient.SqlConnection
$sqlConnection.ConnectionString = $connString

# Open the connection to the database
$sqlConnection.Open()

# Import the Excel module to read data from the Excel sheet
Import-Module ImportExcel

# Load the data from the 'TRAINS_DETAIL' sheet in Excel
$excelFilePath = "C:\Users\Connor\Downloads\CY22.xlsx"  # Replace with your actual file path
$trainData = Import-Excel -Path $excelFilePath -WorksheetName "TRAINS_DETAIL"

# Create a hash table to store railroad_name and their corresponding railroad_id
$railroadIds = @{}

# Get all railroads and their corresponding IDs from the railroad table (if they exist)
$railroadQuery = "SELECT railroad_id, railroad_name FROM dbo.railroad"
$command = $sqlConnection.CreateCommand()
$command.CommandText = $railroadQuery
$reader = $command.ExecuteReader()

# Populate the hash table with existing railroads
while ($reader.Read()) {
    $railroadIds[$reader["railroad_name"]] = $reader["railroad_id"]
}
$reader.Close()

# Prepare the SQL insert query for dbo.railroad table (no railroad_id in the insert)
$insertQuery = "INSERT INTO dbo.railroad (railroad_name) VALUES (@railroad_name); SELECT SCOPE_IDENTITY();"

# Prepare the SQL command object
$command = $sqlConnection.CreateCommand()
$command.CommandText = $insertQuery

# Add parameter for railroad_name
$command.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@railroad_name", [System.Data.SqlDbType]::NVarChar, 255)))

# Loop through each row of train data from the Excel sheet
foreach ($row in $trainData) {
    $railroadName = $row.RAILROAD_NAME  # Ensure the column name matches in Excel

    # Replace null or empty railroad_name with "Unknown" (or handle as needed)
    if ([string]::IsNullOrWhiteSpace($railroadName)) {
        $railroadName = "Unknown"  # Replace with whatever default value you prefer
    }

    # Check if the railroad already has a railroad_id
    if (-not $railroadIds.ContainsKey($railroadName)) {
        # If railroad does not exist, insert it and get the new railroad_id
        $command.Parameters["@railroad_name"].Value = $railroadName

        # Execute the insert query and retrieve the new railroad_id
        $newRailroadId = $command.ExecuteScalar()

        # Add the new railroad_id to the hash table
        $railroadIds[$railroadName] = $newRailroadId
    }
}

# Close the SQL connection after inserting all rows
$sqlConnection.Close()

Write-Host "Data inserted successfully into dbo.railroad table."
