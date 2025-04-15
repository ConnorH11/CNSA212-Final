using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form3 : Form
    {
        private string connectionString = "Server=100.84.117.15; Database=FINAL; User Id=connor; Password=FinalJawn1; TrustServerCertificate=true;";

        public Form3()
        {
            InitializeComponent();
            LoadData(); // Load data into DataGridView when the form opens
        }

        private void label1_Click(object sender, EventArgs e) // Title Label
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Data Grid View click event
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Search Box
        {
        }

        private void button1_Click(object sender, EventArgs e) // Search button
        {
            string searchText = textBox1.Text;

            // Check if searchText is not empty
            if (!string.IsNullOrEmpty(searchText))
            {
                var dataView = (dataGridView1.DataSource as DataTable)?.DefaultView;
                if (dataView != null)
                {
                    // Use LIKE with partial match for seqnos, allowing partial string matches on the converted seqnos
                    dataView.RowFilter = $"Convert(seqnos, 'System.String') LIKE '%{searchText}%'";
                }
            }
            else
            {
                // Clear filter and reload data when search box is cleared
                var dataView = (dataGridView1.DataSource as DataTable)?.DefaultView;
                if (dataView != null)
                {
                    dataView.RowFilter = string.Empty;
                }
                LoadData();
            }
        }

        // Double-click on a row to open detailed view in Form10
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row data
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Extract the data for the selected incident
                string seqnos = row.Cells["seqnos"].Value.ToString();
                string date_time_received = row.Cells["date_time_received"].Value.ToString();
                string date_time_complete = row.Cells["date_time_complete"].Value.ToString();
                string call_type = row.Cells["call_type"].Value.ToString();
                string responsible_city = row.Cells["responsible_city"].Value.ToString();
                string responsible_state = row.Cells["responsible_state"].Value.ToString();
                string responsible_zip = row.Cells["responsible_zip"].Value.ToString();
                string description_of_incident = row.Cells["description_of_incident"].Value.ToString();
                string type_of_incident = row.Cells["type_of_incident"].Value.ToString();
                string incident_cause = row.Cells["incident_cause"].Value.ToString();
                string injury_count = row.Cells["injury_count"].Value.ToString();
                string hospitalization_count = row.Cells["hospitalization_count"].Value.ToString();
                string fatality_count = row.Cells["fatality_count"].Value.ToString();
                string company_id = row.Cells["company_id"].Value.ToString();
                string railroad_id = row.Cells["railroad_id"].Value.ToString();
                string incident_train_id = row.Cells["incident_train_id"].Value.ToString();

                // Open Form10 and pass the incident details
                Form10 form10 = new Form10(seqnos, date_time_received, date_time_complete, call_type, responsible_city, responsible_state, responsible_zip,
                                            description_of_incident, type_of_incident, incident_cause, injury_count, hospitalization_count, fatality_count, company_id, railroad_id, incident_train_id);
                form10.ShowDialog(); // Open Form10 as a dialog
            }
        }

        // Method to load data into DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT seqnos, date_time_received, call_type, responsible_state, type_of_incident,
                   date_time_complete, responsible_city, responsible_zip, description_of_incident,
                   incident_cause, injury_count, hospitalization_count, fatality_count, company_id,
                   railroad_id, incident_train_id
            FROM incident";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Hide unnecessary columns after loading data
                dataGridView1.Columns["date_time_complete"].Visible = false;
                dataGridView1.Columns["responsible_city"].Visible = false;
                dataGridView1.Columns["responsible_zip"].Visible = false;
                dataGridView1.Columns["description_of_incident"].Visible = false;
                dataGridView1.Columns["incident_cause"].Visible = false;
                dataGridView1.Columns["injury_count"].Visible = false;
                dataGridView1.Columns["hospitalization_count"].Visible = false;
                dataGridView1.Columns["fatality_count"].Visible = false;
                dataGridView1.Columns["company_id"].Visible = false;
                dataGridView1.Columns["railroad_id"].Visible = false;
                dataGridView1.Columns["incident_train_id"].Visible = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

    }
}
