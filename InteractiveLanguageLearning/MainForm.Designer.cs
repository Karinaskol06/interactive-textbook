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
            btnReading = new Button();
            btnGrammar = new Button();
            btnProgress = new Button();
            lblUserStats = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Sitka Heading", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(102, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(736, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Інтерактивний підручник для вивчення мов";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbLanguages
            // 
            cmbLanguages.BackColor = Color.FromArgb(217, 204, 162);
            cmbLanguages.DropDownHeight = 150;
            cmbLanguages.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguages.FlatStyle = FlatStyle.Flat;
            cmbLanguages.Font = new Font("Bookman Old Style", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbLanguages.FormattingEnabled = true;
            cmbLanguages.IntegralHeight = false;
            cmbLanguages.ItemHeight = 20;
            cmbLanguages.Location = new Point(203, 41);
            cmbLanguages.Name = "cmbLanguages";
            cmbLanguages.Size = new Size(222, 28);
            cmbLanguages.TabIndex = 2;
            // 
            // lblSelectLanguage
            // 
            lblSelectLanguage.AutoSize = true;
            lblSelectLanguage.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSelectLanguage.Location = new Point(21, 42);
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
            btnVocabulary.Location = new Point(65, 110);
            btnVocabulary.Name = "btnVocabulary";
            btnVocabulary.Size = new Size(338, 38);
            btnVocabulary.TabIndex = 3;
            btnVocabulary.Text = "Словниковий запас";
            btnVocabulary.UseVisualStyleBackColor = false;
            btnVocabulary.Click += btnVocabulary_Click;
            // 
            // btnReading
            // 
            btnReading.BackColor = Color.FromArgb(181, 169, 114);
            btnReading.FlatStyle = FlatStyle.Popup;
            btnReading.Font = new Font("Sitka Small", 10.8F, FontStyle.Bold);
            btnReading.Location = new Point(65, 157);
            btnReading.Name = "btnReading";
            btnReading.Size = new Size(338, 38);
            btnReading.TabIndex = 4;
            btnReading.Text = "Читання";
            btnReading.UseVisualStyleBackColor = false;
            btnReading.Click += btnReading_Click;
            // 
            // btnGrammar
            // 
            btnGrammar.BackColor = Color.FromArgb(111, 207, 234);
            btnGrammar.FlatStyle = FlatStyle.Popup;
            btnGrammar.Font = new Font("Sitka Small", 10.8F, FontStyle.Bold);
            btnGrammar.Location = new Point(65, 205);
            btnGrammar.Name = "btnGrammar";
            btnGrammar.Size = new Size(338, 38);
            btnGrammar.TabIndex = 5;
            btnGrammar.Text = "Граматика";
            btnGrammar.UseVisualStyleBackColor = false;
            // 
            // btnProgress
            // 
            btnProgress.BackColor = Color.FromArgb(118, 166, 166);
            btnProgress.FlatStyle = FlatStyle.Flat;
            btnProgress.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProgress.Location = new Point(561, 346);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new Size(338, 40);
            btnProgress.TabIndex = 6;
            btnProgress.Text = "Мій прогрес";
            btnProgress.UseVisualStyleBackColor = false;
            btnProgress.Click += btnProgress_Click;
            // 
            // lblUserStats
            // 
            lblUserStats.AutoSize = true;
            lblUserStats.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUserStats.Location = new Point(561, 106);
            lblUserStats.Name = "lblUserStats";
            lblUserStats.Size = new Size(133, 23);
            lblUserStats.TabIndex = 7;
            lblUserStats.Text = "Статистика";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(38, 37, 35);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Sitka Display", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = SystemColors.Info;
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
            btnRegister.BackColor = Color.FromArgb(64, 34, 42);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Sitka Display", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRegister.ForeColor = SystemColors.Info;
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
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnGrammar);
            panel1.Controls.Add(cmbLanguages);
            panel1.Controls.Add(lblSelectLanguage);
            panel1.Controls.Add(btnReading);
            panel1.Controls.Add(btnVocabulary);
            panel1.Location = new Point(33, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 280);
            panel1.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 219, 197);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(940, 490);
            Controls.Add(lblUserStats);
            Controls.Add(panel1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(btnProgress);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            Font = new Font("Bookman Old Style", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
        private Button btnReading;
        private Button btnGrammar;
        private Button btnProgress;
        private Label lblUserStats;
        private Button btnLogin;
        private Button btnRegister;
        private Panel panel1;
    }
}
