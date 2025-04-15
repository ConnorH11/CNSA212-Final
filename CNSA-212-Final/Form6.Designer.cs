namespace CNSA_212_Final
{
    partial class Form6
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
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 9);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 2;
            label1.Text = "User Maintenance";
            label1.Click += label1_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(47, 57);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(697, 23);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TextChanged += textBox1_TextChanged;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(47, 117);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(697, 23);
            txtConfirmPassword.TabIndex = 4;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(305, 169);
            button1.Name = "button1";
            button1.Size = new Size(150, 23);
            button1.TabIndex = 5;
            button1.Text = "Change Password";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 39);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 6;
            label2.Text = "New Password";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 99);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 7;
            label3.Text = "Confirm New Password";
            label3.Click += label3_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 246);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(label1);
            Name = "Form6";
            Text = "Form6";
            Load += Form6_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button button1;
        private Label label2;
        private Label label3;
    }
}