using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CNSA_212_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e) //Please log in to your account
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //Username textbox
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //password textbox
        {

        }

        private void label1_Click(object sender, EventArgs e) //Username Label
        {

        }

        private void label2_Click(object sender, EventArgs e) //Password Label
        {

        }

        private void button1_Click(object sender, EventArgs e) //Login Button
        {
            //get user input from text boxes 
            
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //checks if input is empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            //authenticate user
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT HashedPassword, Salt, DisplayName FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHashedPassword = reader["HashedPassword"].ToString();
                                string storedSalt = reader["Salt"].ToString();
                                string displayName = reader["DisplayName"].ToString();
   
                                //hash input password with the stored salt
                                string hashedInputPassword = User.HashPassword(password, storedSalt);

                                //compare the input password with salt
                                if (hashedInputPassword == storedHashedPassword)
                                {
                                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Hide(); //hides login form
                                    
                                    Form2 mainform = new Form2(username, displayName);
                                    mainform.ShowDialog();

                                    //close the login form
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
       
    }
}
    
