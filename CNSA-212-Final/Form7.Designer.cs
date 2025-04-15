namespace CNSA_212_Final
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            txtDateTimeReceived = new TextBox();
            txtCallType = new TextBox();
            txtIncidentCause = new TextBox();
            txtInjuryCount = new TextBox();
            txtFatalityCount = new TextBox();
            txtHospitializationCount = new TextBox();
            txtTypeOfIncident = new TextBox();
            txtDescription = new TextBox();
            txtResponsibleZIP = new TextBox();
            txtResponsibleState = new TextBox();
            txtResponsibleCity = new TextBox();
            txtDateTimeComplete = new TextBox();
            button1 = new Button();
            txtSeqnos = new TextBox();
            label14 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Insert new incident";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(258, 15);
            label2.TabIndex = 1;
            label2.Text = "Date and time received (EX:2022-01-13 15:20:00)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 114);
            label3.Name = "label3";
            label3.Size = new Size(264, 15);
            label3.TabIndex = 2;
            label3.Text = "Date and time complete (EX:2022-01-13 15:20:00)";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 3;
            label4.Text = "Call Type";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 217);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 4;
            label5.Text = "Responsible City";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 264);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 5;
            label6.Text = "Responsible State";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 312);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 6;
            label7.Text = "Responsible ZIP";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 356);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 7;
            label8.Text = "Description";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 399);
            label9.Name = "label9";
            label9.Size = new Size(91, 15);
            label9.TabIndex = 8;
            label9.Text = "Type of Incident";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 447);
            label10.Name = "label10";
            label10.Size = new Size(85, 15);
            label10.TabIndex = 9;
            label10.Text = "Incident Cause";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 491);
            label11.Name = "label11";
            label11.Size = new Size(73, 15);
            label11.TabIndex = 10;
            label11.Text = "Injury Count";
            label11.Click += label11_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 545);
            label12.Name = "label12";
            label12.Size = new Size(122, 15);
            label12.TabIndex = 11;
            label12.Text = "Hospitalization Count";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 599);
            label13.Name = "label13";
            label13.Size = new Size(81, 15);
            label13.TabIndex = 12;
            label13.Text = "Fatality Count";
            label13.Click += label13_Click;
            // 
            // txtDateTimeReceived
            // 
            txtDateTimeReceived.Location = new Point(12, 70);
            txtDateTimeReceived.Name = "txtDateTimeReceived";
            txtDateTimeReceived.Size = new Size(193, 23);
            txtDateTimeReceived.TabIndex = 13;
            txtDateTimeReceived.TextChanged += textBox1_TextChanged;
            // 
            // txtCallType
            // 
            txtCallType.Location = new Point(12, 186);
            txtCallType.Name = "txtCallType";
            txtCallType.Size = new Size(193, 23);
            txtCallType.TabIndex = 14;
            txtCallType.TextChanged += textBox2_TextChanged;
            // 
            // txtIncidentCause
            // 
            txtIncidentCause.Location = new Point(12, 465);
            txtIncidentCause.Name = "txtIncidentCause";
            txtIncidentCause.Size = new Size(193, 23);
            txtIncidentCause.TabIndex = 15;
            txtIncidentCause.TextChanged += textBox3_TextChanged;
            // 
            // txtInjuryCount
            // 
            txtInjuryCount.Location = new Point(12, 509);
            txtInjuryCount.Name = "txtInjuryCount";
            txtInjuryCount.Size = new Size(193, 23);
            txtInjuryCount.TabIndex = 16;
            txtInjuryCount.TextChanged += textBox4_TextChanged;
            // 
            // txtFatalityCount
            // 
            txtFatalityCount.Location = new Point(13, 617);
            txtFatalityCount.Name = "txtFatalityCount";
            txtFatalityCount.Size = new Size(192, 23);
            txtFatalityCount.TabIndex = 17;
            txtFatalityCount.TextChanged += textBox5_TextChanged;
            // 
            // txtHospitializationCount
            // 
            txtHospitializationCount.Location = new Point(12, 563);
            txtHospitializationCount.Name = "txtHospitializationCount";
            txtHospitializationCount.Size = new Size(193, 23);
            txtHospitializationCount.TabIndex = 18;
            txtHospitializationCount.TextChanged += textBox6_TextChanged;
            // 
            // txtTypeOfIncident
            // 
            txtTypeOfIncident.Location = new Point(12, 421);
            txtTypeOfIncident.Name = "txtTypeOfIncident";
            txtTypeOfIncident.Size = new Size(193, 23);
            txtTypeOfIncident.TabIndex = 19;
            txtTypeOfIncident.TextChanged += textBox7_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 374);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(462, 23);
            txtDescription.TabIndex = 20;
            txtDescription.TextChanged += textBox8_TextChanged;
            // 
            // txtResponsibleZIP
            // 
            txtResponsibleZIP.Location = new Point(12, 330);
            txtResponsibleZIP.Name = "txtResponsibleZIP";
            txtResponsibleZIP.Size = new Size(193, 23);
            txtResponsibleZIP.TabIndex = 21;
            txtResponsibleZIP.TextChanged += textBox9_TextChanged;
            // 
            // txtResponsibleState
            // 
            txtResponsibleState.Location = new Point(12, 282);
            txtResponsibleState.Name = "txtResponsibleState";
            txtResponsibleState.Size = new Size(193, 23);
            txtResponsibleState.TabIndex = 22;
            txtResponsibleState.TextChanged += textBox10_TextChanged;
            // 
            // txtResponsibleCity
            // 
            txtResponsibleCity.Location = new Point(12, 235);
            txtResponsibleCity.Name = "txtResponsibleCity";
            txtResponsibleCity.Size = new Size(193, 23);
            txtResponsibleCity.TabIndex = 23;
            txtResponsibleCity.TextChanged += textBox11_TextChanged;
            // 
            // txtDateTimeComplete
            // 
            txtDateTimeComplete.Location = new Point(12, 132);
            txtDateTimeComplete.Name = "txtDateTimeComplete";
            txtDateTimeComplete.Size = new Size(193, 23);
            txtDateTimeComplete.TabIndex = 24;
            txtDateTimeComplete.TextChanged += textBox12_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(19, 713);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 25;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtSeqnos
            // 
            txtSeqnos.Location = new Point(13, 672);
            txtSeqnos.Name = "txtSeqnos";
            txtSeqnos.Size = new Size(186, 23);
            txtSeqnos.TabIndex = 26;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 654);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 27;
            label14.Text = "SEQNOS";
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 748);
            Controls.Add(label14);
            Controls.Add(txtSeqnos);
            Controls.Add(button1);
            Controls.Add(txtDateTimeComplete);
            Controls.Add(txtResponsibleCity);
            Controls.Add(txtResponsibleState);
            Controls.Add(txtResponsibleZIP);
            Controls.Add(txtDescription);
            Controls.Add(txtTypeOfIncident);
            Controls.Add(txtHospitializationCount);
            Controls.Add(txtFatalityCount);
            Controls.Add(txtInjuryCount);
            Controls.Add(txtIncidentCause);
            Controls.Add(txtCallType);
            Controls.Add(txtDateTimeReceived);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form7";
            Text = "Form7";
            Load += Form7_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtDateTimeReceived;
        private TextBox txtCallType;
        private TextBox txtIncidentCause;
        private TextBox txtInjuryCount;
        private TextBox txtFatalityCount;
        private TextBox txtHospitializationCount;
        private TextBox txtTypeOfIncident;
        private TextBox txtDescription;
        private TextBox txtResponsibleZIP;
        private TextBox txtResponsibleState;
        private TextBox txtResponsibleCity;
        private TextBox txtDateTimeComplete;
        private Button button1;
        private TextBox txtSeqnos;
        private Label label14;
    }
}