namespace InteractiveLanguageLearning
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUsername.Location = new Point(40, 56);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(147, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Ім'я користувача:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(250, 221, 165);
            txtUsername.Location = new Point(234, 53);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(192, 30);
            txtUsername.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(40, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(164, 23);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Електронна адреса:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(250, 221, 165);
            txtEmail.Location = new Point(234, 102);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(192, 30);
            txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 156);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(250, 221, 165);
            txtPassword.Location = new Point(234, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(192, 30);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(40, 209);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(170, 23);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Підтвердьте пароль:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(250, 221, 165);
            txtConfirmPassword.Location = new Point(234, 206);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(192, 30);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(147, 191, 166);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRegister.Location = new Point(218, 412);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(189, 41);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Далі";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(242, 82, 82);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(494, 412);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(189, 41);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(250, 240, 207);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblConfirmPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblPassword);
            panel1.Location = new Point(218, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 281);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(250, 240, 207);
            label1.Font = new Font("Sitka Heading", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(299, 23);
            label1.Name = "label1";
            label1.Size = new Size(302, 43);
            label1.TabIndex = 11;
            label1.Text = "Форма для реєстрації";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 216, 188);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(900, 518);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Реєстрація в системі";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnCancel;
        private Panel panel1;
        private Label label1;
    }
}