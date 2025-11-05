namespace InteractiveLanguageLearning
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblTitle = new Label();
            cmbLanguages = new ComboBox();
            lblSelectLanguage = new Label();
            btnVocabulary = new Button();
            btnProgress = new Button();
            lblUserStats = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            panel1 = new Panel();
            btnTeacherPanel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(250, 240, 207);
            lblTitle.Font = new Font("Sitka Heading", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(115, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(711, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Інтерактивний посібник для вивчення мов";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbLanguages
            // 
            cmbLanguages.BackColor = Color.FromArgb(250, 240, 207);
            cmbLanguages.DropDownHeight = 150;
            cmbLanguages.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguages.FlatStyle = FlatStyle.Flat;
            cmbLanguages.Font = new Font("Bookman Old Style", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbLanguages.FormattingEnabled = true;
            cmbLanguages.IntegralHeight = false;
            cmbLanguages.ItemHeight = 20;
            cmbLanguages.Location = new Point(291, 27);
            cmbLanguages.Name = "cmbLanguages";
            cmbLanguages.Size = new Size(222, 28);
            cmbLanguages.TabIndex = 2;
            // 
            // lblSelectLanguage
            // 
            lblSelectLanguage.AutoSize = true;
            lblSelectLanguage.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSelectLanguage.Location = new Point(109, 28);
            lblSelectLanguage.Name = "lblSelectLanguage";
            lblSelectLanguage.Size = new Size(156, 23);
            lblSelectLanguage.TabIndex = 1;
            lblSelectLanguage.Text = "Оберіть мову: ";
            // 
            // btnVocabulary
            // 
            btnVocabulary.BackColor = Color.FromArgb(114, 181, 178);
            btnVocabulary.FlatStyle = FlatStyle.Popup;
            btnVocabulary.Font = new Font("Sitka Small", 10.8F, FontStyle.Bold);
            btnVocabulary.Location = new Point(47, 80);
            btnVocabulary.Name = "btnVocabulary";
            btnVocabulary.Size = new Size(218, 91);
            btnVocabulary.TabIndex = 3;
            btnVocabulary.Text = "Перейти до тем";
            btnVocabulary.UseVisualStyleBackColor = false;
            btnVocabulary.Click += btnVocabulary_Click;
            // 
            // btnProgress
            // 
            btnProgress.BackColor = Color.FromArgb(118, 166, 166);
            btnProgress.FlatStyle = FlatStyle.Popup;
            btnProgress.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProgress.Location = new Point(47, 190);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new Size(218, 42);
            btnProgress.TabIndex = 6;
            btnProgress.Text = "Мій прогрес";
            btnProgress.UseVisualStyleBackColor = false;
            btnProgress.Click += btnProgress_Click;
            // 
            // lblUserStats
            // 
            lblUserStats.AutoSize = true;
            lblUserStats.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUserStats.Location = new Point(325, 80);
            lblUserStats.Name = "lblUserStats";
            lblUserStats.Size = new Size(133, 23);
            lblUserStats.TabIndex = 7;
            lblUserStats.Text = "Статистика";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(250, 221, 165);
            btnLogin.BackgroundImageLayout = ImageLayout.Center;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Sitka Display", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = SystemColors.ControlText;
            btnLogin.Location = new Point(323, 419);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(139, 44);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Увійти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(242, 153, 133);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Sitka Display", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRegister.ForeColor = SystemColors.ControlText;
            btnRegister.Location = new Point(478, 419);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(139, 44);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Реєстрація";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(250, 240, 207);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnTeacherPanel);
            panel1.Controls.Add(lblUserStats);
            panel1.Controls.Add(cmbLanguages);
            panel1.Controls.Add(lblSelectLanguage);
            panel1.Controls.Add(btnVocabulary);
            panel1.Controls.Add(btnProgress);
            panel1.Location = new Point(157, 96);
            panel1.Name = "panel1";
            panel1.Size = new Size(626, 280);
            panel1.TabIndex = 10;
            // 
            // btnTeacherPanel
            // 
            btnTeacherPanel.FlatStyle = FlatStyle.Popup;
            btnTeacherPanel.Font = new Font("Bookman Old Style", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnTeacherPanel.Location = new Point(325, 190);
            btnTeacherPanel.Name = "btnTeacherPanel";
            btnTeacherPanel.Size = new Size(236, 42);
            btnTeacherPanel.TabIndex = 8;
            btnTeacherPanel.Text = "Панель вчителя";
            btnTeacherPanel.UseVisualStyleBackColor = true;
            btnTeacherPanel.Visible = false;
            btnTeacherPanel.Click += btnTeacherPanel_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 219, 197);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(940, 490);
            Controls.Add(panel1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            Font = new Font("Bookman Old Style", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Інтерактивний підручник мов";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ComboBox cmbLanguages;
        private Label lblSelectLanguage;
        private Button btnVocabulary;
        private Button btnProgress;
        private Label lblUserStats;
        private Button btnLogin;
        private Button btnRegister;
        private Panel panel1;
        private Button btnTeacherPanel;
    }
}
