using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) //Insert new incident label
        {

        }

        private void label2_Click(object sender, EventArgs e) //date time received label
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //date time received textbox
        {

        }

        private void label3_Click(object sender, EventArgs e) //date time complete label
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e) //date time complete textbox
        {

        }

        private void label4_Click(object sender, EventArgs e) //call type
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //call type textbox
        {

        }

        private void label5_Click(object sender, EventArgs e) //responsible city label
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e) //responsible city textbox
        {

        }

        private void label6_Click(object sender, EventArgs e) //responsible state label
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e) //responsible state textbox
        {

        }

        private void label7_Click(object sender, EventArgs e) //responsible zip label
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e) //repsonsible zip textbox
        {

        }

        private void label8_Click(object sender, EventArgs e) //description label
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e) //description textbox
        {

        }

        private void label9_Click(object sender, EventArgs e) //type of incident label
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) //type of incident textbox
        {

        }

        private void label10_Click(object sender, EventArgs e) //incident cause label
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //incident cause textbox
        {

        }

        private void label11_Click(object sender, EventArgs e) //injury count label
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //injury count textbox
        {

        }

        private void Form7_Load(object sender, EventArgs e) //hospitalization count label
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //hospitalization count textbox
        {

        }

        private void label13_Click(object sender, EventArgs e) //Fatality Count Label
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) //fatality count textbox
        {

        }

        private void button1_Click(object sender, EventArgs e) //insert button
        {
            //gets values from text boxes
            string dateReceived = txtDateTimeReceived.Text;
            string dateComplete = txtDateTimeComplete.Text;
            string callType = txtCallType.Text;
            string responsibleCity = txtResponsibleCity.Text;
            string responsibleState = txtResponsibleState.Text;
            string responsibleZIP = txtResponsibleZIP.Text;
            string description = txtDescription.Text;
            string incidentType = txtTypeOfIncident.Text;
            string incidentCause = txtIncidentCause.Text;
            string injuryCount = txtInjuryCount.Text;
            string hospitalCount = txtHospitializationCount.Text;
            string fatalityCount = txtFatalityCount.Text;
            string seqnos = txtSeqnos.Text;

            //ensures no empty fields 
            if (string.IsNullOrEmpty(dateReceived) || 
                string.IsNullOrEmpty(dateComplete) ||
                string.IsNullOrEmpty(responsibleCity) || 
                string.IsNullOrEmpty(callType) || 
                string.IsNullOrEmpty(responsibleState) || 
                string.IsNullOrEmpty(responsibleZIP) || 
                string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(incidentType) ||
                string.IsNullOrEmpty(incidentCause) ||
                string.IsNullOrEmpty(injuryCount) ||
                string.IsNullOrEmpty(hospitalCount) || 
                string.IsNullOrEmpty(fatalityCount) ||
                string.IsNullOrEmpty(seqnos))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                
            }
            //adds it to the db hopefully 
            else
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                     INSERT INTO incident ( seqnos, 
                                            date_time_received, 
                                            date_time_complete, 
                                            call_type, 
                                            responsible_city,   
                                            responsible_state, 
                                            responsible_zip, 
                                            description_of_incident,
                                            fatality_count, 
                                            type_of_incident,
                                            incident_cause, 
                                            injury_count,
                                            hospitalization_count)
                     VALUES (@seqnos, 
                             @dateReceived, 
                             @dateComplete, 
                             @callType, 
                             @responsibleCity, 
                             @responsibleState, 
                             @responsibleZIP, 
                             @description, 
                             @fatalityCount, 
                             @incidentType, 
                             @incidentCause, 
                             @injuryCount, 
                             @hospitalCount)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@seqnos", seqnos);
                        cmd.Parameters.AddWithValue("@dateReceived", dateReceived);
                        cmd.Parameters.AddWithValue("@dateComplete", dateComplete);
                        cmd.Parameters.AddWithValue("@callType", callType);
                        cmd.Parameters.AddWithValue("@responsibleCity", responsibleCity);
                        cmd.Parameters.AddWithValue("@responsibleState", responsibleState);
                        cmd.Parameters.AddWithValue("@responsibleZIP", responsibleZIP);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@fatalityCount", fatalityCount);
                        cmd.Parameters.AddWithValue("@incidentType", incidentType);
                        cmd.Parameters.AddWithValue("@incidentCause", incidentCause);
                        cmd.Parameters.AddWithValue("@injuryCount", injuryCount);
                        cmd.Parameters.AddWithValue("@hospitalCount", hospitalCount);

                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("it worked");
                }
            }
            
           
        }
    }
}
