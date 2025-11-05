namespace InteractiveLanguageLearning
{
    partial class TopicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopicForm));
            panelSections = new Panel();
            lblLanguageName = new Label();
            btnBack = new Button();
            SuspendLayout();
            // 
            // panelSections
            // 
            panelSections.AutoScroll = true;
            panelSections.BackColor = Color.FromArgb(250, 240, 207);
            panelSections.Location = new Point(12, 60);
            panelSections.Name = "panelSections";
            panelSections.Size = new Size(651, 568);
            panelSections.TabIndex = 0;
            // 
            // lblLanguageName
            // 
            lblLanguageName.AutoSize = true;
            lblLanguageName.BackColor = Color.FromArgb(250, 240, 207);
            lblLanguageName.Font = new Font("Sitka Heading", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblLanguageName.Location = new Point(25, 18);
            lblLanguageName.Name = "lblLanguageName";
            lblLanguageName.Size = new Size(91, 39);
            lblLanguageName.TabIndex = 1;
            lblLanguageName.Text = "Мова:";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(242, 153, 133);
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.Location = new Point(274, 651);
            btnBack.Name = "btnBack";
            btnBack.RightToLeft = RightToLeft.No;
            btnBack.Size = new Size(126, 47);
            btnBack.TabIndex = 2;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // TopicForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(181, 169, 114);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(675, 725);
            Controls.Add(btnBack);
            Controls.Add(lblLanguageName);
            Controls.Add(panelSections);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TopicForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вибір теми";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSections;
        private Label lblLanguageName;
        private Button btnBack;
    }
}