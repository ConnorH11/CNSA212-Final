using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSA_212_Final
{
    public class UserSeeder
    {
        public static void SeedInitialUser()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                //checks if user table has data
                string checkUserQuery = "SELECT COUNT (*) FROM Users";
                using (SqlCommand cmd = new SqlCommand(checkUserQuery, conn))
                {
                    int userCount = (int)cmd.ExecuteScalar();
                    if (userCount == 0)
                    {
                        Console.WriteLine("No users found. Seeding initial user...");
                        AddInitialUser(conn);
                    }
                    else
                    {
                        Console.WriteLine("Users already exists no need to initialize user seeding.");
                    }

                }
            }
        }

        private static void AddInitialUser(SqlConnection conn)
        {
            //creates the initial user
            User initialUser = new User
            {
                Username = "admin",
                DisplayName = "Administrator"
            };
            bool passwordSet = initialUser.SetPassword("CNSAcnsa1");
            if (passwordSet)
            {
                string query = @"
                        INSERT INTO Users (Username, DisplayName, HashedPassword, Salt)
                        VALUES (@Username, @DisplayName, @HashedPassword, @Salt)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", initialUser.Username);
                    cmd.Parameters.AddWithValue("@DisplayName", initialUser.DisplayName);
                    cmd.Parameters.AddWithValue("@HashedPassword", initialUser.HashedPassword);
                    cmd.Parameters.AddWithValue("@Salt", initialUser.Salt);

                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Initial User Created Cookah");

            }
            else
            {
                Console.WriteLine("Failed to set password, cook again");
            }

        }
        public static void AddNewUser(string username, string displayName, string password)
        {
            //create new user instance 
            User newUser = new User
            {
                Username = username,
                DisplayName = displayName
            };

            //set the password (hashes it and generates the salt
            bool passwordSet = newUser.SetPassword(password);

            if (passwordSet)
            {
                //store it in the db
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                            INSERT INTO Users (Username, DisplayName, HashedPassword, Salt)
                            VALUES (@Username, @DisplayName, @HashedPassword, @Salt)";
                            
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", newUser.Username);
                        cmd.Parameters.AddWithValue("@DisplayName", newUser.DisplayName);
                        cmd.Parameters.AddWithValue("@HashedPassword", newUser.HashedPassword);
                        cmd.Parameters.AddWithValue("@Salt", newUser.Salt);

                        cmd.ExecuteNonQuery ();

                    }
                    Console.WriteLine("new user added papa");
                }
            }
            else
            {
                Console.WriteLine("failed papa kys");
            }
        }
    }
}

