using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form8 : Form
    {
        private string connectionString = "Server=100.84.117.15; Database=FINAL; User Id=connor; Password=FinalJawn1; TrustServerCertificate=true;";
        private string companyName; // To store the company_name

        // Constructor that accepts company details (companyName)
        public Form8(string companyName)
        {
            InitializeComponent();
            this.companyName = companyName;

            // Optionally display the company name in a label on Form8
            label1.Text = $"Incidents for {companyName}";

            LoadIncidents(); // Load incidents for the company
        }

        // Method to load incidents for the selected company based on company_name
        private void LoadIncidents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step 1: Get company_id based on company_name
                string getCompanyIdQuery = @"
                    SELECT company_id
                    FROM company
                    WHERE company_name = @companyName";

                SqlCommand getCompanyIdCmd = new SqlCommand(getCompanyIdQuery, conn);
                getCompanyIdCmd.Parameters.AddWithValue("@companyName", companyName);

                object companyIdObj = getCompanyIdCmd.ExecuteScalar();

                if (companyIdObj != null)
                {
                    string companyId = companyIdObj.ToString(); // Fetch the company_id
                    // Step 2: Query incidents based on the company_id
                    string query = @"
                        SELECT i.seqnos, i.date_time_received, i.call_type, i.responsible_state, i.type_of_incident
                        FROM incident i
                        WHERE i.company_id = @companyId"; // Use the company_id to filter incidents

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@companyId", companyId); // Use the company_id as a parameter

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Check if data was fetched and bind to the DataGridView
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No incidents found for this company.");
                    }
                    else
                    {
                        dataGridView1.DataSource = dataTable; // Bind incident data to DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Company not found.");
                }
            }
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       
        private void label1_Click(object sender, EventArgs e)
        {
       
        }
    }
}
