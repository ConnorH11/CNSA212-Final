using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LogEventViewer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace CNSA_212_Final
{
    public partial class Form2 : Form
    {
        
        public Form2(string username, string displayName)
        {
            InitializeComponent();
            label2.Text = username;
            label3.Text = string.IsNullOrWhiteSpace(displayName)
                          ? GetDisplayNameFromDatabase(username)
                          : displayName;
            LoadIncidentData();
        }

        private void LoadIncidentData()
        {
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conn = DatabaseConnection.GetConnection())
                {
                  
                    string query = "SELECT seqnos, date_time_received, date_time_complete, description_of_incident FROM incident";

                    using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                    {
                        using (Microsoft.Data.SqlClient.SqlDataAdapter adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable; // Bind data to DataGridView
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //this gets the displayname 
        public string GetDisplayNameFromDatabase(string usrname)
        {
            string displayName = null;
            using (Microsoft.Data.SqlClient.SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT DisplayName FROM Users WHERE Username = @Username";
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username",  usrname);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        displayName = result.ToString();
                    }
                }
            }
            return displayName;
        }
        private void button4_Click(object sender, EventArgs e) //Show User Maintenance Button
        {
            Form4 Form4 = new Form4();
            Form4.Show();
        }

        private void label1_Click(object sender, EventArgs e) //Main Screen Label
        {

        }

        private void button1_Click(object sender, EventArgs e) //Show Incidents Button
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Show Companies Button
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Show Railroads Button
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Data Grid View
        {

        }

        private void button5_Click(object sender, EventArgs e) //Insert Incident
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DatabaseConfigForm databaseConfigForm = new DatabaseConfigForm();
            databaseConfigForm.Show();
        }

        private void label2_Click(object sender, EventArgs e) //Users username
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }



        private void button8_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(label2.Text);
            form6.Show();
        }

      

        private void button9_Click(object sender, EventArgs e)
        {
            EventViewer eventViewer = new EventViewer(label2.Text);
            eventViewer.Show();
        }
    }
}
