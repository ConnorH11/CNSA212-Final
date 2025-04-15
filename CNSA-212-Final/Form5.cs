using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form5 : Form
    {
        private string connectionString = "Server=100.84.117.15; Database=FINAL; User Id=connor; Password=FinalJawn1; TrustServerCertificate=true;";

        public Form5()
        {
            InitializeComponent();
            LoadData(); // Load data into DataGridView when the form opens
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Data Grid View
        {
            
        }

        private void label1_Click(object sender, EventArgs e) // Railroads Label
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Search Bar
        {
            
        }

        private void button1_Click(object sender, EventArgs e) // Search Button
        {
            string searchText = textBox1.Text;

            if (!string.IsNullOrEmpty(searchText))
            {
                var dataView = (dataGridView1.DataSource as DataTable)?.DefaultView;
                if (dataView != null)
                {
                    // Apply partial match filter on railroad_id column only
                    dataView.RowFilter = $"Convert(railroad_id, 'System.String') LIKE '%{searchText}%'";
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
                string query = "SELECT railroad_id, railroad_name FROM railroad";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        // Event handler for double-clicking a row in the DataGridView
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Extract the railroad_name from the selected row
                string railroadName = row.Cells["railroad_name"].Value.ToString();

                // Open Form9 and pass the railroad_name
                Form9 form9 = new Form9(railroadName);
                form9.ShowDialog();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
    }
}
