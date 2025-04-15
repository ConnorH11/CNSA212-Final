# Import the Excel data, replacing null values with "Unknown" where necessary
$excelData = Import-Excel -Path "C:\Users\Connor\Downloads\CY22.xlsx" -WorksheetName "CALLS" |
    Select-Object @{Name='company_name'; Expression={ if ($_.RESPONSIBLE_COMPANY -eq $null) { "Unknown" } else { $_.'RESPONSIBLE_COMPANY' }}}, 
                  @{Name='org_type'; Expression={ if ($_.RESPONSIBLE_ORG_TYPE -eq $null) { "Unknown" } else { $_.'RESPONSIBLE_ORG_TYPE' }}}

# Set up the SQL connection
$connectionString = "Server=100.84.117.15;Database=FINAL;User Id=connor;Password=FinalJawn1;"
$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
$connection.Open()

# Create a hash table to store the company_name and their corresponding company_id
$companyIds = @{}

# Get all companies and their corresponding IDs from the company table (if they exist)
$companyQuery = "SELECT company_id, company_name FROM dbo.company"
$command = $connection.CreateCommand()
$command.CommandText = $companyQuery
$reader = $command.ExecuteReader()

# Populate the hash table with existing companies
while ($reader.Read()) {
    $companyIds[$reader["company_name"]] = $reader["company_id"]
}
$reader.Close()

# Convert the data to a DataTable for SqlBulkCopy
$dataTable = New-Object System.Data.DataTable
$companyNameCol = $dataTable.Columns.Add("company_name", [string])
$orgTypeCol = $dataTable.Columns.Add("org_type", [string])

# Populate the DataTable with Excel data
foreach ($row in $excelData) {
    $companyName = $row.company_name
    $orgType = $row.org_type

    # Check if the company already has a company_id
    if (-not $companyIds.ContainsKey($companyName)) {
        # If company does not exist, insert it and get the new company_id
        $insertQuery = "INSERT INTO dbo.company (company_name, org_type) VALUES (@companyName, @orgType); SELECT SCOPE_IDENTITY();"
        $insertCommand = $connection.CreateCommand()
        $insertCommand.CommandText = $insertQuery
        $insertCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@companyName", [System.Data.SqlDbType]::NVarChar, 255))).Value = $companyName
        $insertCommand.Parameters.Add((New-Object Data.SqlClient.SqlParameter("@orgType", [System.Data.SqlDbType]::NVarChar, 255))).Value = $orgType

        # Execute the insert query and retrieve the new company_id
        $newCompanyId = $insertCommand.ExecuteScalar()
        
        # Add the new company_id to the hash table
        $companyIds[$companyName] = $newCompanyId
    }

    # Insert the data into the DataTable with the existing or new company_id
    $dataRow = $dataTable.NewRow()
    $dataRow["company_name"] = $companyName
    $dataRow["org_type"] = $orgType
    $dataTable.Rows.Add($dataRow)
}

# Set up SqlBulkCopy for inserting data
$sqlBulkCopy = New-Object Data.SqlClient.SqlBulkCopy($connection)
$sqlBulkCopy.DestinationTableName = "dbo.company"

# Map the columns explicitly
$sqlBulkCopy.ColumnMappings.Add("company_name", "company_name")
$sqlBulkCopy.ColumnMappings.Add("org_type", "org_type")

# Perform the bulk insert
$sqlBulkCopy.WriteToServer($dataTable)

# Close the SQL connection
$connection.Close()

Write-Host "Data inserted successfully."
