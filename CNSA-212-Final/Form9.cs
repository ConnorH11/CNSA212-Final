using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form9 : Form
    {
        private string connectionString = "Server=100.84.117.15; Database=FINAL; User Id=connor; Password=FinalJawn1; TrustServerCertificate=true;";
        private string railroadName; // To store the railroad_name

        // Constructor that accepts railroad details (railroadName)
        public Form9(string railroadName)
        {
            InitializeComponent();
            this.railroadName = railroadName;

           
            label1.Text = $"Incidents for {railroadName}";

            LoadIncidents(); // Load incidents for the railroad
        }

        // Method to load incidents for the selected railroad based on railroad_name
        private void LoadIncidents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step 1: Get railroad_id based on railroad_name
                string getRailroadIdQuery = @"
                    SELECT railroad_id
                    FROM railroad
                    WHERE railroad_name = @railroadName";

                SqlCommand getRailroadIdCmd = new SqlCommand(getRailroadIdQuery, conn);
                getRailroadIdCmd.Parameters.AddWithValue("@railroadName", railroadName);

                object railroadIdObj = getRailroadIdCmd.ExecuteScalar();

                if (railroadIdObj != null)
                {
                    string railroadId = railroadIdObj.ToString(); // Fetch the railroad_id
                    // Step 2: Query incidents based on the railroad_id
                    string query = @"
                        SELECT i.seqnos, i.date_time_received, i.call_type, i.responsible_state, i.type_of_incident
                        FROM incident i
                        WHERE i.railroad_id = @railroadId"; // Use the railroad_id to filter incidents

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@railroadId", railroadId); // Use the railroad_id as a parameter

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Check if data was fetched and bind to the DataGridView
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No incidents found for this railroad.");
                    }
                    else
                    {
                        dataGridView1.DataSource = dataTable; // Bind incident data to DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Railroad not found.");
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
