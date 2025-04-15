namespace CNSA_212_Final
{
    partial class Form9
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 407);
            dataGridView1.TabIndex = 0;
            dataGridView1.ReadOnly = true; // Makes the DataGridView read-only
            dataGridView1.AllowUserToAddRows = false; // Prevents adding new rows
            dataGridView1.AllowUserToDeleteRows = false; // Prevents deleting rows
            dataGridView1.AllowUserToOrderColumns = false; // Optional, prevents column reordering
            dataGridView1.AllowUserToResizeColumns = true; // Allows resizing columns if needed
            dataGridView1.AllowUserToResizeRows = false; // Prevents resizing rows
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(349, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 1;
            label1.Text = "Railroad Incidents";
            label1.Click += label1_Click;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form9";
            Text = "Form9";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
    }
}