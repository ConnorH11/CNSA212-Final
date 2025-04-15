using System;
using System.Windows.Forms;

namespace CNSA_212_Final
{
    public partial class Form10 : Form
    {
        // Constructor accepting the incident details as parameters
        public Form10(string seqnos, string date_time_received, string date_time_complete, string call_type, string responsible_city,
                      string responsible_state, string responsible_zip, string description_of_incident, string type_of_incident,
                      string incident_cause, string injury_count, string hospitalization_count, string fatality_count,
                      string company_id, string railroad_id, string incident_train_id)
        {
            InitializeComponent();

            // Set the values to labels or controls on the form
            labelSeqnos.Text = seqnos;
            labelDateReceived.Text = date_time_received;
            labelDateComplete.Text = date_time_complete;
            labelCallType.Text = call_type;
            labelCity.Text = responsible_city;
            labelState.Text = responsible_state;
            labelZip.Text = responsible_zip;
            labelDescription.Text = description_of_incident;
            labelIncidentType.Text = type_of_incident;
            labelIncidentCause.Text = incident_cause;
            labelInjuryCount.Text = injury_count;
            labelHospitalization.Text = hospitalization_count;
            labelFatalities.Text = fatality_count;
        }

        private void label1_Click(object sender, EventArgs e) // Label click event
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Data Grid View click event
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
