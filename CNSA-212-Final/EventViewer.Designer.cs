namespace LogEventViewer
{
    partial class EventViewer
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnQuery = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(14, 14);
            btnQuery.Margin = new Padding(4, 3, 4, 3);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(88, 27);
            btnQuery.TabIndex = 0;
            btnQuery.Text = "Login Event";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 47);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(905, 458);
            dataGridView1.TabIndex = 1;
            // 
            // EventViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(dataGridView1);
            Controls.Add(btnQuery);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EventViewer";
            Text = "Event Viewer";
            Load += EventViewer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
    }
}
