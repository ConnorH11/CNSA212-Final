using System;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Collections.Generic;

namespace ExcelToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string excelFilePath = @"C:\Users\Connor\Downloads\CY22.xlsx";
            string connectionString = "Server=100.84.117.15; Database=FINAL; User Id=connor; Password=FinalJawn1; TrustServerCertificate=true;";

            var railroadMapping = new Dictionary<string, string>
            {
                { "UNKNOWN SHEEN", "Valid Railroad Name" },
                { "VESSEL", "Valid Vessel Name" },
                { "FIXED", "Valid Fixed Railroad" }
            };

            using (var workbook = new XLWorkbook(excelFilePath))
            {
                var callsSheet = workbook.Worksheet("CALLS");
                var incidentCommonsSheet = workbook.Worksheet("incident_commons");
                var incidentDetailsSheet = workbook.Worksheet("INCIDENT_DETAILS");

                foreach (var row in callsSheet.RowsUsed())
                {
                    var seqnos = row.Cell("A").Value.ToString();
                    DateTime? dateTimeReceived = GetDateTimeFromCell(row.Cell("B"));
                    DateTime? dateTimeComplete = GetDateTimeFromCell(row.Cell("C"));
                    var callType = row.Cell("D").Value.ToString();
                    var responsibleCity = row.Cell("E").Value.ToString();
                    var responsibleState = row.Cell("H").Value.ToString();
                    var responsibleZip = row.Cell("I").Value.ToString();

                    var incidentCommonsRow = incidentCommonsSheet.Row(row.RowNumber());
                    var descriptionOfIncident = incidentCommonsRow.Cell("B").Value.ToString();
                    var typeOfIncident = incidentCommonsRow.Cell("C").Value.ToString();
                    var incidentCause = incidentCommonsRow.Cell("D").Value.ToString();

                    var incidentDetailsRow = incidentDetailsSheet.Row(row.RowNumber());
                    var injuryCount = GetIntFromCell(incidentDetailsRow.Cell("I"));
                    var fatalityCount = GetIntFromCell(incidentDetailsRow.Cell("L"));
                    var hospitalizationCount = GetIntFromCell(incidentDetailsRow.Cell("J"));

                    // Fetch dynamic company_id and railroad_id
                    int companyId = GetCompanyId(connectionString, responsibleCity);
                    int railroadId = GetRailroadId(connectionString, typeOfIncident, railroadMapping);

                    // Incident train ID directly mapped as per original logic
                    var incidentTrainId = GetIncidentTrainId(connectionString);

                    // Insert into the incident table
                    InsertIntoIncidentTable(seqnos, dateTimeReceived, dateTimeComplete, callType, responsibleCity,
                        responsibleState, responsibleZip, descriptionOfIncident, typeOfIncident, incidentCause,
                        injuryCount, hospitalizationCount, fatalityCount, companyId, railroadId, incidentTrainId, connectionString);
                }
            }

            Console.WriteLine("Data inserted successfully.");
        }

        static DateTime? GetDateTimeFromCell(IXLCell cell)
        {
            if (cell.TryGetValue<DateTime>(out DateTime dateValue))
            {
                if (dateValue < new DateTime(1753, 1, 1) || dateValue > new DateTime(9999, 12, 31))
                {
                    Console.WriteLine($"Invalid Date in Cell {cell.Address}: {cell.Value}");
                    return null;
                }
                return dateValue;
            }
            else
            {
                return null;
            }
        }

        static int? GetIntFromCell(IXLCell cell)
        {
            if (int.TryParse(cell.GetValue<string>(), out int result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        static int GetCompanyId(string connectionString, string responsibleCity)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT company_id FROM company WHERE LOWER(company_name) = LOWER(@cityName)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cityName", responsibleCity);
                    var result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int companyId))
                    {
                        return companyId;
                    }
                }
            }

            Console.WriteLine($"No matching company for '{responsibleCity}'");
            return -1; // Default or error case
        }

        static int GetRailroadId(string connectionString, string typeOfIncident, Dictionary<string, string> railroadMapping)
        {
            if (!railroadMapping.TryGetValue(typeOfIncident, out string mappedRailroad))
            {
                Console.WriteLine($"No mapped railroad for '{typeOfIncident}', adding to mapping.");
                railroadMapping[typeOfIncident] = typeOfIncident;
                mappedRailroad = typeOfIncident;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT railroad_id FROM railroad WHERE LOWER(railroad_name) = LOWER(@railroadName)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@railroadName", mappedRailroad);
                    var result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int railroadId))
                    {
                        return railroadId;
                    }
                }
            }

            Console.WriteLine($"No matching railroad for '{mappedRailroad}'");
            return -1; // Default or error case
        }

        static int GetIncidentTrainId(string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT train_id FROM incident_train";

                using (var cmd = new SqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int incidentTrainId))
                    {
                        return incidentTrainId;
                    }
                }
            }

            Console.WriteLine("No incident train found.");
            return -1; // Default or error case
        }

        static void InsertIntoIncidentTable(string seqnos, DateTime? dateTimeReceived, DateTime? dateTimeComplete,
            string callType, string responsibleCity, string responsibleState, string responsibleZip,
            string descriptionOfIncident, string typeOfIncident, string incidentCause,
            int? injuryCount, int? hospitalizationCount, int? fatalityCount,
            int companyId, int railroadId, int incidentTrainId, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO incident 
                (seqnos, date_time_received, date_time_complete, call_type, responsible_city, 
                responsible_state, responsible_zip, description_of_incident, type_of_incident, 
                incident_cause, injury_count, hospitalization_count, fatality_count, 
                company_id, railroad_id, incident_train_id)
                VALUES (@seqnos, @dateTimeReceived, @dateTimeComplete, @callType, @responsibleCity, 
                        @responsibleState, @responsibleZip, @descriptionOfIncident, @typeOfIncident, 
                        @incidentCause, @injuryCount, @hospitalizationCount, @fatalityCount, 
                        @companyId, @railroadId, @incidentTrainId)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@seqnos", (object)seqnos ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dateTimeReceived", (object)dateTimeReceived ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dateTimeComplete", (object)dateTimeComplete ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@callType", (object)callType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@responsibleCity", (object)responsibleCity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@responsibleState", (object)responsibleState ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@responsibleZip", (object)responsibleZip ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@descriptionOfIncident", (object)descriptionOfIncident ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@typeOfIncident", (object)typeOfIncident ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@incidentCause", (object)incidentCause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@injuryCount", (object)injuryCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@hospitalizationCount", (object)hospitalizationCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fatalityCount", (object)fatalityCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@companyId", companyId);
                    cmd.Parameters.AddWithValue("@railroadId", railroadId);
                    cmd.Parameters.AddWithValue("@incidentTrainId", incidentTrainId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
