using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form4 : Form
    {
        private string connectionString = "Server=100.84.117.15; Database=FINAL; User Id=connor; Password=FinalJawn1; TrustServerCertificate=true;";

        public Form4()
        {
            InitializeComponent();
            LoadData(); // Load data into DataGridView when the form opens
        }

        // Double-click on a row to open Form8 with the selected company's details
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Extract the company_name for the selected company
                string companyName = row.Cells["company_name"].Value.ToString();

                // Open Form8 and pass the company_name
                Form8 form8 = new Form8(companyName);
                form8.ShowDialog(); // Show Form8 as a dialog
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;

            if (!string.IsNullOrEmpty(searchText))
            {
                var dataView = (dataGridView1.DataSource as DataTable)?.DefaultView;
                if (dataView != null)
                {
                    // Apply partial match filter on company_name column
                    dataView.RowFilter = $"company_name LIKE '%{searchText}%'";
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

        // Method to load data into DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT company_id, company_name, org_type
                    FROM company";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Bind the data to DataGridView
            }
        }
    }
}
