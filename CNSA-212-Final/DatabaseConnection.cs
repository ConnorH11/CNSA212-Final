using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;

namespace CNSA_212_Final
{
    public static class DatabaseConnection
    {
        private static string connectionString;

        static DatabaseConnection()
        {
            //loads config data from appsettings
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Use AppDomain to reliably locate the file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            //gets the connection string from config
            connectionString = configuration.GetConnectionString("DatabaseConnection");
            //debug to make verify connection string loads
            Console.WriteLine("connection string loaded:" + (string.IsNullOrEmpty(connectionString) ? "Not Found" : "Loaded Successfully"));
        }

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string has not been initialized.");
            }

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        //tests connection returns true if it works false if not 
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    Console.WriteLine("Connection successful.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred with the database connection: " + ex.Message);
                return false;
            }
        }
    }

}
