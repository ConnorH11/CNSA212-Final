using System;
using System.Data;
using System.Windows.Forms;
using CNSA_212_Final;
using Microsoft.Data.SqlClient;

namespace LogEventViewer
{
    public partial class EventViewer : Form
    {
        private string usernames;
        public EventViewer(string username)
        {
            InitializeComponent();
            usernames = username;
            
        }

        private void EventViewer_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView properties here if needed
        }
        //this gets the userID from db 
        private int GetDaUserID(string username)
        {
            int userId = -1;
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    
                    string query = "SELECT UserId FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        object result = cmd.ExecuteScalar();

                        if (result !=null && int.TryParse(result.ToString(), out int id))
                        {
                            userId = id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("an error occurred" +ex.Message);
                }
                
            }
            return userId;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            int userId = GetDaUserID(usernames); // Replace with actual UserId logic
            if (userId == -1)
            {
                MessageBox.Show("user not found my brudda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    // Query to retrieve log events
                    string selectQuery = @"
                        SELECT 
                            UserId,
                            Timestamp,
                            Level,
                            Message,
                            Exception
                        FROM 
                            LogEvents
                        ORDER BY 
                            Timestamp DESC";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    // Query to insert a log event after successful login
                    string insertQuery = @"
                        INSERT INTO LogEvents (UserId, Timestamp, Level, Message, Exception)
                        VALUES (@userId, GETDATE(), 'Information', 'User logged in successfully', NULL);";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
