using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSA_212_Final
{
    public class Startup
    {
        public static void Initialize()
        {
            Console.WriteLine("Starting App Brotha hold on...");

            //test the database connection
            bool isConnected = DatabaseConnection.TestConnection();

            if (!isConnected)
            {
                Console.WriteLine("Unable to connect to the databse sigkill(9) ");

                //this opens db config form if there is a failure
                DatabaseConfigForm configForm = new DatabaseConfigForm();
                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    //re-test the db connection after set config
                    isConnected = DatabaseConnection.TestConnection();
                    if(isConnected)
                    {
                        Console.WriteLine("db connected brotha");
                    }
                    else
                    {
                        Console.WriteLine("db not connected after config bro");
                        Application.Exit();
                    }
                }
                else
                {
                    Console.WriteLine("Db config canceled");
                    Application.Exit();
                }
            }
            if (isConnected)
            {
                //if connected proceed with normal stuff

                //call the method to seed the initial user 
                Console.WriteLine("Database connected successfully.");

                //call the method to seed the initial user 
                UserSeeder.SeedInitialUser();

                Console.WriteLine("Initialization completed");
            }
        }
    }
}
