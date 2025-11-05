namespace InteractiveLanguageLearning
{
    partial class ProgressForm
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
            FastReport.DataVisualization.Charting.ChartArea chartArea1 = new FastReport.DataVisualization.Charting.ChartArea();
            FastReport.DataVisualization.Charting.Legend legend1 = new FastReport.DataVisualization.Charting.Legend();
            FastReport.DataVisualization.Charting.Series series1 = new FastReport.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            chartProgress = new FastReport.DataVisualization.Charting.Chart();
            lblProgressPercentage = new Label();
            label5 = new Label();
            lblTotalScore = new Label();
            label4 = new Label();
            lblCompletedExercises = new Label();
            lblTotalExercises = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPageLanguages = new TabPage();
            dataGridViewLanguages = new DataGridView();
            colLanguage = new DataGridViewTextBoxColumn();
            colCompleted = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colProgress = new DataGridViewTextBoxColumn();
            tabPageDetails = new TabPage();
            progressBarGrammar = new ProgressBar();
            progressBarReading = new ProgressBar();
            progressBarVocabulary = new ProgressBar();
            lblGrammar = new Label();
            lblReading = new Label();
            lblVocabulary = new Label();
            tabPageRecent = new TabPage();
            dataGridViewRecent = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colExercise = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            btnExport = new Button();
            btnClose = new Button();
            tabControl.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartProgress).BeginInit();
            tabPageLanguages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLanguages).BeginInit();
            tabPageDetails.SuspendLayout();
            tabPageRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Controls.Add(tabPageLanguages);
            tabControl.Controls.Add(tabPageDetails);
            tabControl.Controls.Add(tabPageRecent);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(810, 511);
            tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Color.FromArgb(245, 221, 201);
            tabPageGeneral.BorderStyle = BorderStyle.FixedSingle;
            tabPageGeneral.Controls.Add(chartProgress);
            tabPageGeneral.Controls.Add(lblProgressPercentage);
            tabPageGeneral.Controls.Add(label5);
            tabPageGeneral.Controls.Add(lblTotalScore);
            tabPageGeneral.Controls.Add(label4);
            tabPageGeneral.Controls.Add(lblCompletedExercises);
            tabPageGeneral.Controls.Add(lblTotalExercises);
            tabPageGeneral.Controls.Add(label3);
            tabPageGeneral.Controls.Add(label2);
            tabPageGeneral.Controls.Add(label1);
            tabPageGeneral.Location = new Point(4, 32);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Size = new Size(802, 475);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "Загальна статистика";
            // 
            // chartProgress
            // 
            chartProgress.BackColor = Color.FromArgb(242, 153, 133);
            chartArea1.BackImageTransparentColor = Color.Coral;
            chartArea1.BorderColor = Color.DimGray;
            chartArea1.Name = "ChartArea1";
            chartProgress.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartProgress.Legends.Add(legend1);
            chartProgress.Location = new Point(20, 208);
            chartProgress.Name = "chartProgress";
            series1.BackImageTransparentColor = Color.DimGray;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartProgress.Series.Add(series1);
            chartProgress.Size = new Size(760, 252);
            chartProgress.TabIndex = 3;
            chartProgress.Text = "chart1";
            // 
            // lblProgressPercentage
            // 
            lblProgressPercentage.AutoSize = true;
            lblProgressPercentage.Location = new Point(263, 176);
            lblProgressPercentage.Name = "lblProgressPercentage";
            lblProgressPercentage.Size = new Size(55, 23);
            lblProgressPercentage.TabIndex = 2;
            lblProgressPercentage.Text = "label2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 176);
            label5.Name = "label5";
            label5.Size = new Size(80, 23);
            label5.TabIndex = 2;
            label5.Text = "Прогрес:";
            // 
            // lblTotalScore
            // 
            lblTotalScore.AutoSize = true;
            lblTotalScore.Location = new Point(263, 138);
            lblTotalScore.Name = "lblTotalScore";
            lblTotalScore.Size = new Size(55, 23);
            lblTotalScore.TabIndex = 2;
            lblTotalScore.Text = "label2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 138);
            label4.Name = "label4";
            label4.Size = new Size(129, 23);
            label4.TabIndex = 2;
            label4.Text = "Загальний бал:";
            // 
            // lblCompletedExercises
            // 
            lblCompletedExercises.AutoSize = true;
            lblCompletedExercises.Location = new Point(263, 97);
            lblCompletedExercises.Name = "lblCompletedExercises";
            lblCompletedExercises.Size = new Size(55, 23);
            lblCompletedExercises.TabIndex = 2;
            lblCompletedExercises.Text = "label2";
            // 
            // lblTotalExercises
            // 
            lblTotalExercises.AutoSize = true;
            lblTotalExercises.Location = new Point(263, 59);
            lblTotalExercises.Name = "lblTotalExercises";
            lblTotalExercises.Size = new Size(55, 23);
            lblTotalExercises.TabIndex = 2;
            lblTotalExercises.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 97);
            label3.Name = "label3";
            label3.Size = new Size(143, 23);
            label3.TabIndex = 2;
            label3.Text = "Виконано вправ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 59);
            label2.Name = "label2";
            label2.Size = new Size(120, 23);
            label2.TabIndex = 2;
            label2.Text = "Всього вправ:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(20, 11);
            label1.Name = "label1";
            label1.Size = new Size(200, 28);
            label1.TabIndex = 1;
            label1.Text = "Загальна статистика";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPageLanguages
            // 
            tabPageLanguages.Controls.Add(dataGridViewLanguages);
            tabPageLanguages.Location = new Point(4, 29);
            tabPageLanguages.Name = "tabPageLanguages";
            tabPageLanguages.Size = new Size(802, 478);
            tabPageLanguages.TabIndex = 1;
            tabPageLanguages.Text = "Мови";
            tabPageLanguages.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLanguages
            // 
            dataGridViewLanguages.AllowUserToAddRows = false;
            dataGridViewLanguages.AllowUserToDeleteRows = false;
            dataGridViewLanguages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLanguages.BackgroundColor = Color.FromArgb(245, 221, 201);
            dataGridViewLanguages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLanguages.Columns.AddRange(new DataGridViewColumn[] { colLanguage, colCompleted, colTotal, colProgress });
            dataGridViewLanguages.Dock = DockStyle.Fill;
            dataGridViewLanguages.Location = new Point(0, 0);
            dataGridViewLanguages.Name = "dataGridViewLanguages";
            dataGridViewLanguages.RowHeadersVisible = false;
            dataGridViewLanguages.RowHeadersWidth = 51;
            dataGridViewLanguages.Size = new Size(802, 478);
            dataGridViewLanguages.TabIndex = 0;
            dataGridViewLanguages.SelectionChanged += dataGridViewLanguages_SelectionChanged;
            // 
            // colLanguage
            // 
            colLanguage.HeaderText = "Мова";
            colLanguage.MinimumWidth = 6;
            colLanguage.Name = "colLanguage";
            // 
            // colCompleted
            // 
            colCompleted.HeaderText = "Виконано";
            colCompleted.MinimumWidth = 6;
            colCompleted.Name = "colCompleted";
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Всього";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            // 
            // colProgress
            // 
            colProgress.HeaderText = "Прогрес";
            colProgress.MinimumWidth = 6;
            colProgress.Name = "colProgress";
            // 
            // tabPageDetails
            // 
            tabPageDetails.BackColor = Color.FromArgb(245, 221, 201);
            tabPageDetails.Controls.Add(progressBarGrammar);
            tabPageDetails.Controls.Add(progressBarReading);
            tabPageDetails.Controls.Add(progressBarVocabulary);
            tabPageDetails.Controls.Add(lblGrammar);
            tabPageDetails.Controls.Add(lblReading);
            tabPageDetails.Controls.Add(lblVocabulary);
            tabPageDetails.Location = new Point(4, 29);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Size = new Size(802, 478);
            tabPageDetails.TabIndex = 2;
            tabPageDetails.Text = "Типи вправ";
            // 
            // progressBarGrammar
            // 
            progressBarGrammar.Location = new Point(39, 344);
            progressBarGrammar.Name = "progressBarGrammar";
            progressBarGrammar.Size = new Size(179, 29);
            progressBarGrammar.TabIndex = 10;
            // 
            // progressBarReading
            // 
            progressBarReading.Location = new Point(39, 210);
            progressBarReading.Name = "progressBarReading";
            progressBarReading.Size = new Size(179, 29);
            progressBarReading.TabIndex = 9;
            // 
            // progressBarVocabulary
            // 
            progressBarVocabulary.ForeColor = SystemColors.GradientActiveCaption;
            progressBarVocabulary.Location = new Point(39, 81);
            progressBarVocabulary.Name = "progressBarVocabulary";
            progressBarVocabulary.Size = new Size(179, 29);
            progressBarVocabulary.TabIndex = 8;
            // 
            // lblGrammar
            // 
            lblGrammar.AutoSize = true;
            lblGrammar.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblGrammar.Location = new Point(39, 296);
            lblGrammar.Name = "lblGrammar";
            lblGrammar.Size = new Size(97, 23);
            lblGrammar.TabIndex = 5;
            lblGrammar.Text = "Граматика:";
            // 
            // lblReading
            // 
            lblReading.AutoSize = true;
            lblReading.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblReading.Location = new Point(39, 168);
            lblReading.Name = "lblReading";
            lblReading.Size = new Size(81, 23);
            lblReading.TabIndex = 2;
            lblReading.Text = "Читання:";
            // 
            // lblVocabulary
            // 
            lblVocabulary.AutoSize = true;
            lblVocabulary.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblVocabulary.Location = new Point(39, 39);
            lblVocabulary.Name = "lblVocabulary";
            lblVocabulary.Size = new Size(171, 23);
            lblVocabulary.TabIndex = 0;
            lblVocabulary.Text = "Словниковий запас:";
            // 
            // tabPageRecent
            // 
            tabPageRecent.Controls.Add(dataGridViewRecent);
            tabPageRecent.Location = new Point(4, 29);
            tabPageRecent.Name = "tabPageRecent";
            tabPageRecent.Size = new Size(802, 478);
            tabPageRecent.TabIndex = 3;
            tabPageRecent.Text = "Останні дії";
            tabPageRecent.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRecent
            // 
            dataGridViewRecent.AllowUserToAddRows = false;
            dataGridViewRecent.AllowUserToDeleteRows = false;
            dataGridViewRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecent.BackgroundColor = Color.FromArgb(245, 221, 201);
            dataGridViewRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecent.Columns.AddRange(new DataGridViewColumn[] { colDate, colType, colExercise, colStatus, colScore });
            dataGridViewRecent.Dock = DockStyle.Fill;
            dataGridViewRecent.Location = new Point(0, 0);
            dataGridViewRecent.Name = "dataGridViewRecent";
            dataGridViewRecent.RowHeadersVisible = false;
            dataGridViewRecent.RowHeadersWidth = 51;
            dataGridViewRecent.Size = new Size(802, 478);
            dataGridViewRecent.TabIndex = 0;
            dataGridViewRecent.SelectionChanged += dataGridViewRecent_SelectionChanged;
            // 
            // colDate
            // 
            colDate.HeaderText = "Дата";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            // 
            // colType
            // 
            colType.HeaderText = "Тип";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            // 
            // colExercise
            // 
            colExercise.HeaderText = "Вправа";
            colExercise.MinimumWidth = 6;
            colExercise.Name = "colExercise";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Статус";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            // 
            // colScore
            // 
            colScore.HeaderText = "Бали";
            colScore.MinimumWidth = 6;
            colScore.Name = "colScore";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(147, 191, 166);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Location = new Point(250, 517);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 43);
            btnExport.TabIndex = 1;
            btnExport.Text = "Експорт";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(242, 82, 82);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(467, 517);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 43);
            btnClose.TabIndex = 1;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 221, 201);
            ClientSize = new Size(810, 572);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProgressForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProgressForm";
            tabControl.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartProgress).EndInit();
            tabPageLanguages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewLanguages).EndInit();
            tabPageDetails.ResumeLayout(false);
            tabPageDetails.PerformLayout();
            tabPageRecent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private TabPage tabPageLanguages;
        private TabPage tabPageDetails;
        private TabPage tabPageRecent;
        private Label lblProgressPercentage;
        private Label label5;
        private Label lblTotalScore;
        private Label label4;
        private Label lblCompletedExercises;
        private Label lblTotalExercises;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridViewLanguages;
        private DataGridViewTextBoxColumn colLanguage;
        private DataGridViewTextBoxColumn colCompleted;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colProgress;
        private Label lblGrammar;
        private Label lblReading;
        private Label lblVocabulary;
        private DataGridView dataGridViewRecent;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colExercise;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colScore;
        private Button btnExport;
        private Button btnClose;
        private ProgressBar progressBarGrammar;
        private ProgressBar progressBarReading;
        private ProgressBar progressBarVocabulary;
        private FastReport.DataVisualization.Charting.Chart chartProgress;
    }
}