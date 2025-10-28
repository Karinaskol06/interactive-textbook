namespace InteractiveLanguageLearning
{
    partial class ReadingForm
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
            lblTitle = new Label();
            txtReadingText = new TextBox();
            lblQuestion = new Label();
            radioOption1 = new RadioButton();
            radioOption2 = new RadioButton();
            radioOption3 = new RadioButton();
            radioOption4 = new RadioButton();
            btnNext = new Button();
            btnBack = new Button();
            lblProgress = new Label();
            panelText = new Panel();
            panelQuestion = new Panel();
            panelText.SuspendLayout();
            panelQuestion.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(12, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(163, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Заголовок тексту";
            // 
            // txtReadingText
            // 
            txtReadingText.BackColor = Color.FromArgb(224, 216, 188);
            txtReadingText.BorderStyle = BorderStyle.None;
            txtReadingText.Dock = DockStyle.Top;
            txtReadingText.Location = new Point(0, 0);
            txtReadingText.Multiline = true;
            txtReadingText.Name = "txtReadingText";
            txtReadingText.ReadOnly = true;
            txtReadingText.ScrollBars = ScrollBars.Vertical;
            txtReadingText.Size = new Size(497, 325);
            txtReadingText.TabIndex = 0;
            txtReadingText.Text = "Текст для читання";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(19, 23);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(77, 23);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "Питання";
            // 
            // radioOption1
            // 
            radioOption1.AutoSize = true;
            radioOption1.Location = new Point(19, 174);
            radioOption1.Name = "radioOption1";
            radioOption1.Size = new Size(131, 27);
            radioOption1.TabIndex = 2;
            radioOption1.TabStop = true;
            radioOption1.Text = "radioButton1";
            radioOption1.UseVisualStyleBackColor = true;
            radioOption1.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption2
            // 
            radioOption2.AutoSize = true;
            radioOption2.Location = new Point(19, 220);
            radioOption2.Name = "radioOption2";
            radioOption2.Size = new Size(131, 27);
            radioOption2.TabIndex = 2;
            radioOption2.TabStop = true;
            radioOption2.Text = "radioButton1";
            radioOption2.UseVisualStyleBackColor = true;
            radioOption2.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption3
            // 
            radioOption3.AutoSize = true;
            radioOption3.Location = new Point(19, 269);
            radioOption3.Name = "radioOption3";
            radioOption3.Size = new Size(131, 27);
            radioOption3.TabIndex = 2;
            radioOption3.TabStop = true;
            radioOption3.Text = "radioButton1";
            radioOption3.UseVisualStyleBackColor = true;
            radioOption3.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption4
            // 
            radioOption4.AutoSize = true;
            radioOption4.Location = new Point(19, 316);
            radioOption4.Name = "radioOption4";
            radioOption4.Size = new Size(131, 27);
            radioOption4.TabIndex = 2;
            radioOption4.TabStop = true;
            radioOption4.Text = "radioButton1";
            radioOption4.UseVisualStyleBackColor = true;
            radioOption4.CheckedChanged += radioOption_CheckedChanged;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(118, 166, 166);
            btnNext.Enabled = false;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(794, 528);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 51);
            btnNext.TabIndex = 3;
            btnNext.Text = "Далі";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(235, 139, 68);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Location = new Point(683, 528);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 51);
            btnBack.TabIndex = 3;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(373, 417);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(76, 23);
            lblProgress.TabIndex = 4;
            lblProgress.Text = "Прогрес";
            // 
            // panelText
            // 
            panelText.BorderStyle = BorderStyle.FixedSingle;
            panelText.Controls.Add(txtReadingText);
            panelText.Location = new Point(372, 63);
            panelText.Name = "panelText";
            panelText.Size = new Size(499, 330);
            panelText.TabIndex = 5;
            // 
            // panelQuestion
            // 
            panelQuestion.BorderStyle = BorderStyle.FixedSingle;
            panelQuestion.Controls.Add(radioOption1);
            panelQuestion.Controls.Add(lblQuestion);
            panelQuestion.Controls.Add(radioOption2);
            panelQuestion.Controls.Add(radioOption3);
            panelQuestion.Controls.Add(radioOption4);
            panelQuestion.Location = new Point(12, 63);
            panelQuestion.Name = "panelQuestion";
            panelQuestion.Size = new Size(329, 516);
            panelQuestion.TabIndex = 3;
            // 
            // ReadingForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 216, 188);
            ClientSize = new Size(900, 591);
            Controls.Add(panelQuestion);
            Controls.Add(panelText);
            Controls.Add(lblProgress);
            Controls.Add(btnBack);
            Controls.Add(btnNext);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "ReadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Читання";
            panelText.ResumeLayout(false);
            panelText.PerformLayout();
            panelQuestion.ResumeLayout(false);
            panelQuestion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtReadingText;
        private Label lblQuestion;
        private RadioButton radioOption1;
        private RadioButton radioOption2;
        private RadioButton radioOption3;
        private RadioButton radioOption4;
        private Button btnNext;
        private Button btnBack;
        private Label lblProgress;
        private Panel panelText;
        private Panel panelQuestion;
    }
}