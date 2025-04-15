using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CNSA_212_Final
{
    public partial class Form6 : Form
    {

        private string currentUsername; 
        
        public Form6(string username)
        {
            InitializeComponent();
            currentUsername = username;
            
        }
        private void label1_Click(object sender, EventArgs e) //Label For Form
        {

        }

        private void label2_Click(object sender, EventArgs e) //New Password label
        {

        }

        private void label3_Click(object sender, EventArgs e) //Confirm Password label
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //New password box
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //Confirm Password box
        {

        }

        private void button1_Click(object sender, EventArgs e) //Change password button
        {
            // Get the new password values
            string newPassword = txtNewPassword.Text;
            string confirmNewPassword = txtConfirmPassword.Text;

            //check if passwords match 
            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("passwords do not match brotha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //make sure pass is not empty 
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //hash new passowrd with salt 
            User user = new User();
            bool passwordSet = user.SetPassword(newPassword);

            if (!passwordSet)
            {
                MessageBox.Show("error occurred with new passowrd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //update the db with the new hashed password and salt
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    
                    string query = "UPDATE Users SET HashedPassword = @HashedPassword, Salt = @Salt WHERE Username = @Username";

                    using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);
                        cmd.Parameters.AddWithValue("@Salt", user.Salt);
                        cmd.Parameters.AddWithValue("@Username", currentUsername);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("it worked");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error occured while updating password:" +ex.Message," error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
           
        }
    }
}
