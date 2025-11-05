namespace InteractiveLanguageLearning
{
    partial class ExerciseEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExerciseEditForm));
            lblLanguage = new Label();
            cmbLanguage = new ComboBox();
            lblSection = new Label();
            cmbSection = new ComboBox();
            lblTopic = new Label();
            cmbTopic = new ComboBox();
            lblQuestion = new Label();
            txtQuestion = new TextBox();
            lblCorrectAnswer = new Label();
            txtCorrectAnswer = new TextBox();
            lblOptions = new Label();
            txtOptions = new TextBox();
            lblExplanation = new Label();
            txtExplanation = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblTextContent = new Label();
            txtTextContent = new TextBox();
            lblExample = new Label();
            txtExample = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(29, 32);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(52, 24);
            lblLanguage.TabIndex = 0;
            lblLanguage.Text = "Мова";
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(159, 29);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 32);
            cmbLanguage.TabIndex = 1;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(29, 92);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(67, 24);
            lblSection.TabIndex = 2;
            lblSection.Text = "Секція";
            // 
            // cmbSection
            // 
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(159, 89);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(151, 32);
            cmbSection.TabIndex = 3;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged;
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(29, 153);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(51, 24);
            lblTopic.TabIndex = 4;
            lblTopic.Text = "Тема";
            // 
            // cmbTopic
            // 
            cmbTopic.FormattingEnabled = true;
            cmbTopic.Location = new Point(159, 150);
            cmbTopic.Name = "cmbTopic";
            cmbTopic.Size = new Size(151, 32);
            cmbTopic.TabIndex = 5;
            cmbTopic.SelectedIndexChanged += cmbTopic_SelectedIndexChanged;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(19, 332);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(84, 24);
            lblQuestion.TabIndex = 6;
            lblQuestion.Text = "Питання";
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(250, 329);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            txtQuestion.Size = new Size(500, 60);
            txtQuestion.TabIndex = 7;
            // 
            // lblCorrectAnswer
            // 
            lblCorrectAnswer.AutoSize = true;
            lblCorrectAnswer.Location = new Point(19, 438);
            lblCorrectAnswer.Name = "lblCorrectAnswer";
            lblCorrectAnswer.Size = new Size(185, 24);
            lblCorrectAnswer.TabIndex = 8;
            lblCorrectAnswer.Text = "Правильна відповідь";
            // 
            // txtCorrectAnswer
            // 
            txtCorrectAnswer.Location = new Point(250, 438);
            txtCorrectAnswer.Name = "txtCorrectAnswer";
            txtCorrectAnswer.Size = new Size(500, 29);
            txtCorrectAnswer.TabIndex = 7;
            // 
            // lblOptions
            // 
            lblOptions.AutoSize = true;
            lblOptions.Location = new Point(19, 518);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(181, 24);
            lblOptions.TabIndex = 8;
            lblOptions.Text = "Варіанти відповідей";
            // 
            // txtOptions
            // 
            txtOptions.Location = new Point(250, 513);
            txtOptions.Multiline = true;
            txtOptions.Name = "txtOptions";
            txtOptions.ScrollBars = ScrollBars.Vertical;
            txtOptions.Size = new Size(500, 60);
            txtOptions.TabIndex = 7;
            // 
            // lblExplanation
            // 
            lblExplanation.AutoSize = true;
            lblExplanation.Location = new Point(19, 621);
            lblExplanation.Name = "lblExplanation";
            lblExplanation.Size = new Size(102, 24);
            lblExplanation.TabIndex = 8;
            lblExplanation.Text = "Пояснення";
            // 
            // txtExplanation
            // 
            txtExplanation.Location = new Point(250, 621);
            txtExplanation.Multiline = true;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.ScrollBars = ScrollBars.Vertical;
            txtExplanation.Size = new Size(500, 74);
            txtExplanation.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(147, 191, 166);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(936, 432);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 65);
            btnSave.TabIndex = 9;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(242, 153, 133);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(936, 518);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 65);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(9, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(122, 24);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Назва вправи";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(184, 32);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(529, 29);
            txtTitle.TabIndex = 11;
            // 
            // lblTextContent
            // 
            lblTextContent.AutoSize = true;
            lblTextContent.Location = new Point(9, 89);
            lblTextContent.Name = "lblTextContent";
            lblTextContent.Size = new Size(56, 24);
            lblTextContent.TabIndex = 10;
            lblTextContent.Text = "Текст";
            // 
            // txtTextContent
            // 
            txtTextContent.Location = new Point(184, 86);
            txtTextContent.Multiline = true;
            txtTextContent.Name = "txtTextContent";
            txtTextContent.ScrollBars = ScrollBars.Vertical;
            txtTextContent.Size = new Size(529, 103);
            txtTextContent.TabIndex = 11;
            // 
            // lblExample
            // 
            lblExample.AutoSize = true;
            lblExample.Location = new Point(9, 212);
            lblExample.Name = "lblExample";
            lblExample.Size = new Size(83, 24);
            lblExample.TabIndex = 10;
            lblExample.Text = "Приклад";
            // 
            // txtExample
            // 
            txtExample.Location = new Point(184, 209);
            txtExample.Multiline = true;
            txtExample.Name = "txtExample";
            txtExample.ScrollBars = ScrollBars.Vertical;
            txtExample.Size = new Size(529, 76);
            txtExample.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.AccessibleRole = AccessibleRole.Border;
            groupBox1.Controls.Add(cmbSection);
            groupBox1.Controls.Add(lblLanguage);
            groupBox1.Controls.Add(cmbLanguage);
            groupBox1.Controls.Add(lblSection);
            groupBox1.Controls.Add(lblTopic);
            groupBox1.Controls.Add(cmbTopic);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(344, 291);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtExample);
            groupBox2.Controls.Add(lblTitle);
            groupBox2.Controls.Add(lblTextContent);
            groupBox2.Controls.Add(txtTextContent);
            groupBox2.Controls.Add(lblExample);
            groupBox2.Controls.Add(txtTitle);
            groupBox2.Location = new Point(362, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(713, 291);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // ExerciseEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 237, 221);
            ClientSize = new Size(1087, 714);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblExplanation);
            Controls.Add(lblOptions);
            Controls.Add(lblCorrectAnswer);
            Controls.Add(txtExplanation);
            Controls.Add(txtOptions);
            Controls.Add(txtCorrectAnswer);
            Controls.Add(txtQuestion);
            Controls.Add(lblQuestion);
            Font = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ExerciseEditForm";
            Text = "Редагування вправ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLanguage;
        private ComboBox cmbLanguage;
        private Label lblSection;
        private ComboBox cmbSection;
        private Label lblTopic;
        private ComboBox cmbTopic;
        private Label lblQuestion;
        private TextBox txtQuestion;
        private Label lblCorrectAnswer;
        private TextBox txtCorrectAnswer;
        private Label lblOptions;
        private TextBox txtOptions;
        private Label lblExplanation;
        private TextBox txtExplanation;
        private Button btnSave;
        private Button btnCancel;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblTextContent;
        private TextBox txtTextContent;
        private Label lblExample;
        private TextBox textBox1;
        private TextBox txtExample;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}