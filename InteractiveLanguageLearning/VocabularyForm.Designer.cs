namespace InteractiveLanguageLearning
{
    partial class VocabularyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VocabularyForm));
            lblQuestion = new Label();
            radioOption1 = new RadioButton();
            radioOption2 = new RadioButton();
            radioOption3 = new RadioButton();
            radioOption4 = new RadioButton();
            btnNext = new Button();
            lblProgress = new Label();
            panel1 = new Panel();
            pbWordImage = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbWordImage).BeginInit();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblQuestion.Location = new Point(21, 18);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(97, 28);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question";
            // 
            // radioOption1
            // 
            radioOption1.AutoSize = true;
            radioOption1.Location = new Point(21, 76);
            radioOption1.Name = "radioOption1";
            radioOption1.Size = new Size(131, 27);
            radioOption1.TabIndex = 1;
            radioOption1.TabStop = true;
            radioOption1.Text = "radioButton1";
            radioOption1.UseVisualStyleBackColor = true;
            radioOption1.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption2
            // 
            radioOption2.AutoSize = true;
            radioOption2.Location = new Point(21, 110);
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
            radioOption3.Location = new Point(21, 145);
            radioOption3.Name = "radioOption3";
            radioOption3.Size = new Size(131, 27);
            radioOption3.TabIndex = 3;
            radioOption3.TabStop = true;
            radioOption3.Text = "radioButton1";
            radioOption3.UseVisualStyleBackColor = true;
            radioOption3.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption4
            // 
            radioOption4.AutoSize = true;
            radioOption4.Location = new Point(21, 180);
            radioOption4.Name = "radioOption4";
            radioOption4.Size = new Size(131, 27);
            radioOption4.TabIndex = 4;
            radioOption4.TabStop = true;
            radioOption4.Text = "radioButton1";
            radioOption4.UseVisualStyleBackColor = true;
            radioOption4.CheckedChanged += radioOption_CheckedChanged;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(147, 191, 166);
            btnNext.FlatStyle = FlatStyle.Popup;
            btnNext.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnNext.ForeColor = SystemColors.ControlText;
            btnNext.Location = new Point(21, 237);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 34);
            btnNext.TabIndex = 5;
            btnNext.Text = "Далі";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lblProgress.Location = new Point(21, 457);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(88, 23);
            lblProgress.TabIndex = 6;
            lblProgress.Text = "Прогрес: ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(250, 240, 207);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(lblProgress);
            panel1.Controls.Add(lblQuestion);
            panel1.Controls.Add(radioOption1);
            panel1.Controls.Add(radioOption4);
            panel1.Controls.Add(radioOption2);
            panel1.Controls.Add(radioOption3);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(451, 494);
            panel1.TabIndex = 7;
            // 
            // pbWordImage
            // 
            pbWordImage.Image = (Image)resources.GetObject("pbWordImage.Image");
            pbWordImage.Location = new Point(469, 12);
            pbWordImage.Name = "pbWordImage";
            pbWordImage.Size = new Size(419, 494);
            pbWordImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbWordImage.TabIndex = 8;
            pbWordImage.TabStop = false;
            // 
            // VocabularyForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 240, 207);
            ClientSize = new Size(900, 518);
            Controls.Add(pbWordImage);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VocabularyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Словниковий запас";
            Click += radioOption_CheckedChanged;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbWordImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblQuestion;
        private RadioButton radioOption1;
        private RadioButton radioOption2;
        private RadioButton radioOption3;
        private RadioButton radioOption4;
        private Button btnNext;
        private Label lblProgress;
        private Panel panel1;
        private PictureBox pbWordImage;
    }
}