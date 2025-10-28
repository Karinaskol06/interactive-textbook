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
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            lblProgressPercentage = new Label();
            label5 = new Label();
            lblTotalScore = new Label();
            label4 = new Label();
            lblCompletedExercises = new Label();
            lblTotalExercises = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chartProgress = new FastReport.DataVisualization.Charting.Chart();
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
            lblGrammarProgress = new Label();
            label12 = new Label();
            lblReadingProgress = new Label();
            label9 = new Label();
            lblVocabularyProgress = new Label();
            label6 = new Label();
            tabPageRecent = new TabPage();
            dataGridViewRecent = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colExercise = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
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
            tabPageGeneral.Controls.Add(lblProgressPercentage);
            tabPageGeneral.Controls.Add(label5);
            tabPageGeneral.Controls.Add(lblTotalScore);
            tabPageGeneral.Controls.Add(label4);
            tabPageGeneral.Controls.Add(lblCompletedExercises);
            tabPageGeneral.Controls.Add(lblTotalExercises);
            tabPageGeneral.Controls.Add(label3);
            tabPageGeneral.Controls.Add(label2);
            tabPageGeneral.Controls.Add(label1);
            tabPageGeneral.Controls.Add(chartProgress);
            tabPageGeneral.Location = new Point(4, 32);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Size = new Size(802, 475);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "Загальна статистика";
            tabPageGeneral.UseVisualStyleBackColor = true;
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
            // chartProgress
            // 
            chartProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartProgress.BackColor = Color.FromArgb(111, 207, 234);
            chartProgress.BorderlineDashStyle = FastReport.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BackColor = Color.FromArgb(111, 207, 234);
            chartArea1.BackGradientStyle = FastReport.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = Color.White;
            chartArea1.BorderColor = Color.BlanchedAlmond;
            chartArea1.Name = "ChartArea1";
            chartProgress.ChartAreas.Add(chartArea1);
            chartProgress.Location = new Point(8, 221);
            chartProgress.Name = "chartProgress";
            chartProgress.Size = new Size(786, 251);
            chartProgress.TabIndex = 0;
            chartProgress.Text = "chart1";
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
            dataGridViewLanguages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLanguages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLanguages.Columns.AddRange(new DataGridViewColumn[] { colLanguage, colCompleted, colTotal, colProgress });
            dataGridViewLanguages.Dock = DockStyle.Fill;
            dataGridViewLanguages.Location = new Point(0, 0);
            dataGridViewLanguages.Name = "dataGridViewLanguages";
            dataGridViewLanguages.RowHeadersWidth = 51;
            dataGridViewLanguages.Size = new Size(802, 478);
            dataGridViewLanguages.TabIndex = 0;
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
            tabPageDetails.Controls.Add(progressBarGrammar);
            tabPageDetails.Controls.Add(progressBarReading);
            tabPageDetails.Controls.Add(progressBarVocabulary);
            tabPageDetails.Controls.Add(lblGrammarProgress);
            tabPageDetails.Controls.Add(label12);
            tabPageDetails.Controls.Add(lblReadingProgress);
            tabPageDetails.Controls.Add(label9);
            tabPageDetails.Controls.Add(lblVocabularyProgress);
            tabPageDetails.Controls.Add(label6);
            tabPageDetails.Location = new Point(4, 29);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Size = new Size(802, 478);
            tabPageDetails.TabIndex = 2;
            tabPageDetails.Text = "Типи вправ";
            tabPageDetails.UseVisualStyleBackColor = true;
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
            progressBarVocabulary.Location = new Point(39, 81);
            progressBarVocabulary.Name = "progressBarVocabulary";
            progressBarVocabulary.Size = new Size(179, 29);
            progressBarVocabulary.TabIndex = 8;
            // 
            // lblGrammarProgress
            // 
            lblGrammarProgress.AutoSize = true;
            lblGrammarProgress.Location = new Point(295, 344);
            lblGrammarProgress.Name = "lblGrammarProgress";
            lblGrammarProgress.Size = new Size(165, 23);
            lblGrammarProgress.TabIndex = 7;
            lblGrammarProgress.Text = "lblGrammarProgress";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.Location = new Point(39, 296);
            label12.Name = "label12";
            label12.Size = new Size(97, 23);
            label12.TabIndex = 5;
            label12.Text = "Граматика:";
            // 
            // lblReadingProgress
            // 
            lblReadingProgress.AutoSize = true;
            lblReadingProgress.Location = new Point(295, 216);
            lblReadingProgress.Name = "lblReadingProgress";
            lblReadingProgress.Size = new Size(155, 23);
            lblReadingProgress.TabIndex = 4;
            lblReadingProgress.Text = "lblReadingProgress";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.Location = new Point(39, 168);
            label9.Name = "label9";
            label9.Size = new Size(81, 23);
            label9.TabIndex = 2;
            label9.Text = "Читання:";
            // 
            // lblVocabularyProgress
            // 
            lblVocabularyProgress.AutoSize = true;
            lblVocabularyProgress.Location = new Point(295, 87);
            lblVocabularyProgress.Name = "lblVocabularyProgress";
            lblVocabularyProgress.Size = new Size(177, 23);
            lblVocabularyProgress.TabIndex = 1;
            lblVocabularyProgress.Text = "lblVocabularyProgress";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(39, 39);
            label6.Name = "label6";
            label6.Size = new Size(171, 23);
            label6.TabIndex = 0;
            label6.Text = "Словниковий запас:";
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
            dataGridViewRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecent.Columns.AddRange(new DataGridViewColumn[] { colDate, colType, colExercise, colStatus, colScore });
            dataGridViewRecent.Dock = DockStyle.Fill;
            dataGridViewRecent.Location = new Point(0, 0);
            dataGridViewRecent.Name = "dataGridViewRecent";
            dataGridViewRecent.RowHeadersWidth = 51;
            dataGridViewRecent.Size = new Size(802, 478);
            dataGridViewRecent.TabIndex = 0;
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
            // btnRefresh
            // 
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(247, 517);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 50);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Оновити";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExport
            // 
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Location = new Point(347, 517);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 50);
            btnExport.TabIndex = 1;
            btnExport.Text = "Експорт";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(447, 517);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 579);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(btnRefresh);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
        private FastReport.DataVisualization.Charting.Chart chartProgress;
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
        private Label lblGrammarProgress;
        private Label label12;
        private Label lblReadingProgress;
        private Label label9;
        private Label lblVocabularyProgress;
        private Label label6;
        private DataGridView dataGridViewRecent;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colExercise;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colScore;
        private Button btnRefresh;
        private Button btnExport;
        private Button btnClose;
        private ProgressBar progressBarGrammar;
        private ProgressBar progressBarReading;
        private ProgressBar progressBarVocabulary;
    }
}