using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            // get the values from the textboxes
            string username = txtUserName.Text.Trim();
            string displayName = txtDisplayName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // check if password matches confirm password
            if (password != confirmPassword)
            {
                MessageBox.Show("passwords do not match but try again buddy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution if passwords don't match
            }

            //ensures no empty fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //call addnewuser method in userseeder
            try
            {
                UserSeeder.AddNewUser(username, displayName, password);
                MessageBox.Show("User Added Cookah!!!!!!!!!!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //clear txtboxes after adding user
                txtUserName.Clear();
                txtDisplayName.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Did not work you messed it up, fix it." + ex.Message,"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
