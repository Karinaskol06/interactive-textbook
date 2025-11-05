namespace InteractiveLanguageLearning
{
    partial class GrammarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrammarForm));
            lblTitle = new Label();
            lblExplanation = new Label();
            lblProgress = new Label();
            panelFillInTheBlanks = new Panel();
            lblFillInTheBlanksTitle = new Label();
            panelDragDrop = new Panel();
            panelDragLabels = new Panel();
            lblDragDropTitle = new Label();
            panelMultipleChoice = new Panel();
            radioOption4 = new RadioButton();
            radioOption3 = new RadioButton();
            radioOption2 = new RadioButton();
            radioOption1 = new RadioButton();
            lblQuestion = new Label();
            btnBack = new Button();
            btnCheckAnswer = new Button();
            btnNext = new Button();
            panelFillInTheBlanks.SuspendLayout();
            panelDragDrop.SuspendLayout();
            panelMultipleChoice.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Sitka Heading", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(13, 24);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(64, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // lblExplanation
            // 
            lblExplanation.AutoSize = true;
            lblExplanation.Font = new Font("Sitka Subheading", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblExplanation.Location = new Point(14, 69);
            lblExplanation.Name = "lblExplanation";
            lblExplanation.Size = new Size(53, 24);
            lblExplanation.TabIndex = 1;
            lblExplanation.Text = "label1";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblProgress.Location = new Point(742, 26);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(53, 23);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "label1";
            // 
            // panelFillInTheBlanks
            // 
            panelFillInTheBlanks.BackColor = Color.FromArgb(227, 214, 188);
            panelFillInTheBlanks.BorderStyle = BorderStyle.FixedSingle;
            panelFillInTheBlanks.Controls.Add(lblFillInTheBlanksTitle);
            panelFillInTheBlanks.Location = new Point(20, 136);
            panelFillInTheBlanks.Name = "panelFillInTheBlanks";
            panelFillInTheBlanks.Size = new Size(855, 307);
            panelFillInTheBlanks.TabIndex = 3;
            panelFillInTheBlanks.Visible = false;
            // 
            // lblFillInTheBlanksTitle
            // 
            lblFillInTheBlanksTitle.AutoSize = true;
            lblFillInTheBlanksTitle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblFillInTheBlanksTitle.Location = new Point(10, 10);
            lblFillInTheBlanksTitle.Name = "lblFillInTheBlanksTitle";
            lblFillInTheBlanksTitle.Size = new Size(168, 23);
            lblFillInTheBlanksTitle.TabIndex = 0;
            lblFillInTheBlanksTitle.Text = "Заповніть пропуски";
            // 
            // panelDragDrop
            // 
            panelDragDrop.AllowDrop = true;
            panelDragDrop.BackColor = Color.FromArgb(227, 214, 188);
            panelDragDrop.BorderStyle = BorderStyle.FixedSingle;
            panelDragDrop.Controls.Add(panelDragLabels);
            panelDragDrop.Controls.Add(lblDragDropTitle);
            panelDragDrop.Location = new Point(20, 136);
            panelDragDrop.Name = "panelDragDrop";
            panelDragDrop.Size = new Size(858, 352);
            panelDragDrop.TabIndex = 4;
            panelDragDrop.Visible = false;
            panelDragDrop.DragDrop += panelDragDrop_DragDrop;
            panelDragDrop.DragEnter += panelDragDrop_DragEnter;
            // 
            // panelDragLabels
            // 
            panelDragLabels.Location = new Point(21, 49);
            panelDragLabels.Name = "panelDragLabels";
            panelDragLabels.Size = new Size(815, 120);
            panelDragLabels.TabIndex = 1;
            panelDragLabels.Visible = false;
            // 
            // lblDragDropTitle
            // 
            lblDragDropTitle.AutoSize = true;
            lblDragDropTitle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblDragDropTitle.Location = new Point(10, 10);
            lblDragDropTitle.Name = "lblDragDropTitle";
            lblDragDropTitle.Size = new Size(124, 23);
            lblDragDropTitle.TabIndex = 0;
            lblDragDropTitle.Text = "Drag and Drop";
            // 
            // panelMultipleChoice
            // 
            panelMultipleChoice.BackColor = Color.FromArgb(227, 214, 188);
            panelMultipleChoice.BorderStyle = BorderStyle.FixedSingle;
            panelMultipleChoice.Controls.Add(radioOption4);
            panelMultipleChoice.Controls.Add(radioOption3);
            panelMultipleChoice.Controls.Add(radioOption2);
            panelMultipleChoice.Controls.Add(radioOption1);
            panelMultipleChoice.Controls.Add(lblQuestion);
            panelMultipleChoice.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            panelMultipleChoice.Location = new Point(20, 136);
            panelMultipleChoice.Name = "panelMultipleChoice";
            panelMultipleChoice.Size = new Size(858, 307);
            panelMultipleChoice.TabIndex = 5;
            panelMultipleChoice.Visible = false;
            // 
            // radioOption4
            // 
            radioOption4.AutoSize = true;
            radioOption4.Location = new Point(20, 159);
            radioOption4.Name = "radioOption4";
            radioOption4.Size = new Size(133, 28);
            radioOption4.TabIndex = 1;
            radioOption4.TabStop = true;
            radioOption4.Text = "radioButton1";
            radioOption4.UseVisualStyleBackColor = true;
            radioOption4.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption3
            // 
            radioOption3.AutoSize = true;
            radioOption3.Location = new Point(20, 126);
            radioOption3.Name = "radioOption3";
            radioOption3.Size = new Size(133, 28);
            radioOption3.TabIndex = 1;
            radioOption3.TabStop = true;
            radioOption3.Text = "radioButton1";
            radioOption3.UseVisualStyleBackColor = true;
            radioOption3.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption2
            // 
            radioOption2.AutoSize = true;
            radioOption2.Location = new Point(20, 93);
            radioOption2.Name = "radioOption2";
            radioOption2.Size = new Size(133, 28);
            radioOption2.TabIndex = 1;
            radioOption2.TabStop = true;
            radioOption2.Text = "radioButton1";
            radioOption2.UseVisualStyleBackColor = true;
            radioOption2.CheckedChanged += radioOption_CheckedChanged;
            // 
            // radioOption1
            // 
            radioOption1.AutoSize = true;
            radioOption1.Location = new Point(20, 60);
            radioOption1.Name = "radioOption1";
            radioOption1.Size = new Size(133, 28);
            radioOption1.TabIndex = 1;
            radioOption1.TabStop = true;
            radioOption1.Text = "radioButton1";
            radioOption1.UseVisualStyleBackColor = true;
            radioOption1.CheckedChanged += radioOption_CheckedChanged;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblQuestion.Location = new Point(10, 10);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(59, 25);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "label1";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(242, 153, 133);
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Sitka Text", 10.1999989F);
            btnBack.Location = new Point(269, 527);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(109, 45);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnCheckAnswer
            // 
            btnCheckAnswer.BackColor = Color.FromArgb(147, 191, 166);
            btnCheckAnswer.FlatStyle = FlatStyle.Popup;
            btnCheckAnswer.Font = new Font("Sitka Text", 10.1999989F);
            btnCheckAnswer.Location = new Point(384, 527);
            btnCheckAnswer.Name = "btnCheckAnswer";
            btnCheckAnswer.Size = new Size(129, 45);
            btnCheckAnswer.TabIndex = 6;
            btnCheckAnswer.Text = "Перевірити";
            btnCheckAnswer.UseVisualStyleBackColor = false;
            btnCheckAnswer.Click += btnCheckAnswer_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(130, 189, 186);
            btnNext.FlatStyle = FlatStyle.Popup;
            btnNext.Font = new Font("Sitka Text", 10.1999989F);
            btnNext.Location = new Point(519, 527);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(109, 45);
            btnNext.TabIndex = 7;
            btnNext.Text = "Наступна";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // GrammarForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 237, 221);
            ClientSize = new Size(896, 584);
            Controls.Add(btnNext);
            Controls.Add(btnCheckAnswer);
            Controls.Add(panelMultipleChoice);
            Controls.Add(btnBack);
            Controls.Add(panelDragDrop);
            Controls.Add(panelFillInTheBlanks);
            Controls.Add(lblProgress);
            Controls.Add(lblExplanation);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "GrammarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Граматичні вправи";
            panelFillInTheBlanks.ResumeLayout(false);
            panelFillInTheBlanks.PerformLayout();
            panelDragDrop.ResumeLayout(false);
            panelDragDrop.PerformLayout();
            panelMultipleChoice.ResumeLayout(false);
            panelMultipleChoice.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblExplanation;
        private Label lblProgress;
        private Panel panelFillInTheBlanks;
        private Label lblFillInTheBlanksTitle;
        private Panel panelDragDrop;
        private Label lblDragDropTitle;
        private Panel panelDragLabels;
        private Panel panelMultipleChoice;
        private RadioButton radioOption4;
        private RadioButton radioOption3;
        private RadioButton radioOption2;
        private RadioButton radioOption1;
        private Label lblQuestion;
        private Button btnBack;
        private Button btnCheckAnswer;
        private Button btnNext;
    }
}