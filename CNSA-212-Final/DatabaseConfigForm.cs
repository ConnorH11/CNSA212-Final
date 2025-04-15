using System;
using System.Collections.Generic;
using System.Drawing.Text;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;

namespace CNSA_212_Final
{
    public partial class DatabaseConfigForm : Form
    {
        private IConfigurationRoot configuration;
        public DatabaseConfigForm()
        {

            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                configuration = configBuilder.Build();

                //get the connection string from config
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    // Parse the connection string and populate text boxes
                    var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
                    txtServer.Text = builder.DataSource;
                    txtDatabase.Text = builder.InitialCatalog;
                    txtUserId.Text = builder.UserID;
                    txtPassword.Text = builder.Password;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading it bro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void UpdateAppSettings(string connectionString)
        {
            try
            {
                // Path to appsettings.json
                var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
                var json = File.ReadAllText(appSettingsPath);
                var jsonObj = JObject.Parse(json);

                //update the connection string in appsetting.json 
                jsonObj["ConnectionStrings"]["DatabaseConnection"] = connectionString;

                //writes the updates json back to the file 
                File.WriteAllText(appSettingsPath, jsonObj.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating settings papa : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void InitializeComponent()
        {
            lblServer = new Label();
            txtServer = new TextBox();
            lblDatabase = new Label();
            txtDatabase = new TextBox();
            lblUserId = new Label();
            lblPassword = new Label();
            txtUserId = new TextBox();
            txtPassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(12, 18);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(42, 15);
            lblServer.TabIndex = 0;
            lblServer.Text = "Server:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(81, 10);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(167, 23);
            txtServer.TabIndex = 1;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Location = new Point(10, 59);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(58, 15);
            lblDatabase.TabIndex = 2;
            lblDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(81, 59);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(167, 23);
            txtDatabase.TabIndex = 3;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(12, 111);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(47, 15);
            lblUserId.TabIndex = 4;
            lblUserId.Text = "User ID:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(8, 151);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(81, 103);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(167, 23);
            txtUserId.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(81, 148);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(167, 23);
            txtPassword.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(22, 188);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(226, 44);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(22, 254);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(226, 39);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // DatabaseConfigForm
            // 
            ClientSize = new Size(267, 305);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(txtUserId);
            Controls.Add(lblPassword);
            Controls.Add(lblUserId);
            Controls.Add(txtDatabase);
            Controls.Add(lblDatabase);
            Controls.Add(txtServer);
            Controls.Add(lblServer);
            Name = "DatabaseConfigForm";
            Load += DatabaseConfigForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //get user input from text boxes
            string server = txtServer.Text;
            string database = txtDatabase.Text;
            string userId = txtUserId.Text;
            string password = txtPassword.Text;

            //construct the connection string 
            string connectionString = $"Server={server};Database={database};User Id={userId};Password={password};TrustServerCertificate=True;";

            //update the appsettings.json with the new connection string 
            UpdateAppSettings(connectionString);

            MessageBox.Show("Database connection settings saved lfg", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            this.DialogResult = DialogResult.OK;
            

        }

        private Label lblServer;
        private TextBox txtServer;
        private Label lblDatabase;
        private TextBox txtDatabase;
        private Label lblUserId;
        private Label lblPassword;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private Button btnSave;
        private Button btnCancel;

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatabaseConfigForm_Load(object sender, EventArgs e)
        {

        }
    }
}
   