namespace InteractiveLanguageLearning
{
    partial class TeacherPanelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherPanelForm));
            btnRefresh = new Button();
            btnClose = new Button();
            treeViewExercises = new TreeView();
            btnAddExercise = new Button();
            btnEditExercise = new Button();
            btnDeleteExercise = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(118, 166, 166);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(870, 449);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(118, 34);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Оновити";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(242, 82, 82);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(870, 538);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(118, 34);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // treeViewExercises
            // 
            treeViewExercises.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewExercises.BackColor = Color.FromArgb(250, 240, 207);
            treeViewExercises.FullRowSelect = true;
            treeViewExercises.HideSelection = false;
            treeViewExercises.Indent = 25;
            treeViewExercises.ItemHeight = 25;
            treeViewExercises.Location = new Point(12, 50);
            treeViewExercises.Name = "treeViewExercises";
            treeViewExercises.Size = new Size(976, 378);
            treeViewExercises.TabIndex = 0;
            // 
            // btnAddExercise
            // 
            btnAddExercise.BackColor = Color.FromArgb(147, 191, 166);
            btnAddExercise.FlatStyle = FlatStyle.Flat;
            btnAddExercise.Location = new Point(12, 449);
            btnAddExercise.Name = "btnAddExercise";
            btnAddExercise.Size = new Size(180, 35);
            btnAddExercise.TabIndex = 1;
            btnAddExercise.Text = "Додати вправу";
            btnAddExercise.UseVisualStyleBackColor = false;
            btnAddExercise.Click += btnAddExercise_Click;
            // 
            // btnEditExercise
            // 
            btnEditExercise.BackColor = Color.FromArgb(250, 221, 165);
            btnEditExercise.FlatStyle = FlatStyle.Flat;
            btnEditExercise.Location = new Point(12, 490);
            btnEditExercise.Name = "btnEditExercise";
            btnEditExercise.Size = new Size(180, 35);
            btnEditExercise.TabIndex = 2;
            btnEditExercise.Text = "Редагувати";
            btnEditExercise.UseVisualStyleBackColor = false;
            btnEditExercise.Click += btnEditExercise_Click;
            // 
            // btnDeleteExercise
            // 
            btnDeleteExercise.BackColor = Color.FromArgb(242, 153, 133);
            btnDeleteExercise.FlatStyle = FlatStyle.Flat;
            btnDeleteExercise.Location = new Point(12, 531);
            btnDeleteExercise.Name = "btnDeleteExercise";
            btnDeleteExercise.Size = new Size(180, 36);
            btnDeleteExercise.TabIndex = 3;
            btnDeleteExercise.Text = "Видалити";
            btnDeleteExercise.UseVisualStyleBackColor = false;
            btnDeleteExercise.Click += btnDeleteExercise_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Sitka Text", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(325, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(351, 33);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Панель управління вправами";
            // 
            // TeacherPanelForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 237, 221);
            ClientSize = new Size(1000, 584);
            Controls.Add(lblTitle);
            Controls.Add(btnDeleteExercise);
            Controls.Add(btnEditExercise);
            Controls.Add(btnAddExercise);
            Controls.Add(treeViewExercises);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Font = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TeacherPanelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель вчителя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRefresh;
        private Button btnClose;
        private TreeView treeViewExercises;
        private Button btnAddExercise;
        private Button btnEditExercise;
        private Button btnDeleteExercise;
        private Label lblTitle;
    }
}