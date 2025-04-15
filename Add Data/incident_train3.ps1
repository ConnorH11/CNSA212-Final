# Define SQL connection
$connString = "Server=100.84.117.15;Database=FINAL;User Id=connor;Password=FinalJawn1;"
$sqlConnection = New-Object System.Data.SqlClient.SqlConnection
$sqlConnection.ConnectionString = $connString
$sqlConnection.Open()

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

# Loop through each row of train data from the Excel sheet
foreach ($row in $trainData) {
    # Extract values from the Excel sheet
    $nameNumber = $row.TRAIN_NAME_NUMBER
    $trainType = $row.TRAIN_TYPE
    $railroadName = $row.RAILROAD_NAME

    # Replace null or empty railroad_name with "Unknown" (or handle as needed)
    if ([string]::IsNullOrWhiteSpace($railroadName)) {
        $railroadName = "Unknown"  # Replace with your preferred default value
    }

    # Debugging: print the railroad_name value for each row
    Write-Host "Processing Train: $nameNumber - Railroad Name: '$railroadName'"

    # Check if the railroad already has a railroad_id
    if (-not $railroadIds.ContainsKey($railroadName)) {
        # Lookup the railroad_id from the dbo.railroad table based on railroad_name
        $railroadIdQuery = "SELECT railroad_id FROM dbo.railroad WHERE railroad_name = @railroadName"
        $command = $sqlConnection.CreateCommand()
        $command.CommandText = $railroadIdQuery

        # Add the railroad_name parameter to the command
        $command.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@railroadName", [Data.SqlDbType]::NVarChar, 255))).Value = $railroadName

        # Execute the query and retrieve the railroad_id
        $railroadId = $command.ExecuteScalar()

        # Check if the railroad_id was found
        if ($railroadId -eq $null) {
            Write-Host "Skipping Train $nameNumber due to missing Railroad ID for '$railroadName'"
            continue
        }

        # Add the new railroad_id to the hash table
        $railroadIds[$railroadName] = $railroadId
    }
    else {
        $railroadId = $railroadIds[$railroadName]  # Use the existing railroad_id from the hash table
    }

    # Set the parameters for each row, but omit train_id (identity column is auto-generated)
    $insertQuery = "INSERT INTO dbo.incident_train (name_number, train_type, railroad_id) VALUES (@name_number, @train_type, @railroad_id)"
    $insertCommand = $sqlConnection.CreateCommand()
    $insertCommand.CommandText = $insertQuery
    $insertCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@name_number", [Data.SqlDbType]::NVarChar, 255))).Value = $nameNumber
    $insertCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@train_type", [Data.SqlDbType]::NVarChar, 50))).Value = $trainType
    $insertCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@railroad_id", [Data.SqlDbType]::Int))).Value = $railroadId

    # Execute the SQL insert command
    try {
        $insertCommand.ExecuteNonQuery()
        Write-Host "Inserted Train: $nameNumber successfully."
    }
    catch {
        Write-Host "Error inserting Train: $nameNumber - $($_.Exception.Message)"
    }
}

# Close the SQL connection after inserting all rows
$sqlConnection.Close()

Write-Host "Data inserted successfully into dbo.incident_train table."
