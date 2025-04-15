using Microsoft.Extensions.Configuration;

namespace CNSA_212_Final
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //this initializes windows form settings, moved it up cause might fix initialization error
            ApplicationConfiguration.Initialize();

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Add appsettings.json
                .AddEnvironmentVariables(); // add environment variables

            Configuration = builder.Build();

            Startup.Initialize();
            
            Application.Run(new Form1());
            
        }
    }
   
}