namespace CNSA_212_Final
{
    partial class Form11
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
            btnAddUser = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDisplayName = new TextBox();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            SuspendLayout();
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(45, 188);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(214, 33);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 30);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 1;
            label1.Text = "Display Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 63);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 2;
            label2.Text = "User Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 98);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 137);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 4;
            label4.Text = "Confirm Password";
            // 
            // txtDisplayName
            // 
            txtDisplayName.Location = new Point(159, 22);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(100, 23);
            txtDisplayName.TabIndex = 5;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(159, 55);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(100, 23);
            txtUserName.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(159, 90);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(159, 129);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 23);
            txtConfirmPassword.TabIndex = 8;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 298);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(txtDisplayName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddUser);
            Name = "Form11";
            Text = "Form11";
            Load += Form11_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddUser;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtDisplayName;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
    }
}