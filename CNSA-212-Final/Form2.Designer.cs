namespace CNSA_212_Final
{
    partial class Form2
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button5 = new Button();
            label2 = new Label();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(28, 67);
            button1.Name = "button1";
            button1.Size = new Size(173, 23);
            button1.TabIndex = 0;
            button1.Text = "Show Incidents";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(28, 112);
            button2.Name = "button2";
            button2.Size = new Size(173, 23);
            button2.TabIndex = 1;
            button2.Text = "Show Companies";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(28, 160);
            button3.Name = "button3";
            button3.Size = new Size(173, 23);
            button3.TabIndex = 2;
            button3.Text = "Show Railroads";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(28, 205);
            button4.Name = "button4";
            button4.Size = new Size(173, 23);
            button4.TabIndex = 3;
            button4.Text = "Show User Maintenance";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(253, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(535, 426);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 37);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 5;
            label1.Text = "Main Screen";
            label1.Click += label1_Click;
            // 
            // button5
            // 
            button5.Location = new Point(28, 212);
            button5.Name = "button5";
            button5.Size = new Size(173, 23);
            button5.TabIndex = 6;
            button5.Text = "Insert Incident";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 7;
            label2.Text = "Will be username";
            label2.Click += label2_Click;
            // 
            // button6
            // 
            button6.Location = new Point(28, 255);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(173, 25);
            button6.TabIndex = 8;
            button6.Text = "Database Configuration";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(28, 304);
            button7.Name = "button7";
            button7.Size = new Size(173, 23);
            button7.TabIndex = 9;
            button7.Text = "Add New User";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(28, 352);
            button8.Name = "button8";
            button8.Size = new Size(173, 24);
            button8.TabIndex = 10;
            button8.Text = "Change Password";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(28, 406);
            button9.Name = "button9";
            button9.Size = new Size(173, 23);
            button9.TabIndex = 11;
            button9.Text = "LogEvent";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 12);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 12;
            label3.Text = "label3";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 475);
            Controls.Add(label3);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button5;
        private Label label2;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Label label3;
    }
}