using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class ProgressForm : Form
    {
        private User _currentUser;
        private UserService _userService;
        private LanguageService _languageService;
        private ExerciseService _exerciseService;

        public ProgressForm(User user)
        {
            InitializeComponent();
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _userService = new UserService();
            _languageService = new LanguageService();
            _exerciseService = new ExerciseService();

            LoadProgressData();
            SetupChart();
        }

        private void LoadProgressData()
        {
            if (_currentUser == null) return;

            try
            {
                var stats = _userService.GetUserStats(_currentUser.Id);
                lblTotalExercises.Text = stats.TotalExercises.ToString();
                lblCompletedExercises.Text = stats.CompletedExercises.ToString();
                lblTotalScore.Text = stats.TotalScore.ToString();
                lblProgressPercentage.Text = $"{stats.ProgressPercentage:F1}%";

                LoadLanguageProgress();
                LoadExerciseTypeProgress();
                LoadRecentActivities();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLanguageProgress()
        {
            var languages = _languageService.GetAllLanguages();
            dataGridViewLanguages.Rows.Clear();

            foreach (var language in languages)
            {
                var totalExercises = language.Sections
                    .SelectMany(s => s.Topics)
                    .SelectMany(t => t.VocabularyExercises)
                    .Count() +
                    language.Sections
                    .SelectMany(s => s.Topics)
                    .SelectMany(t => t.ReadingExercises)
                    .Count() +
                    language.Sections
                    .SelectMany(s => s.Topics)
                    .SelectMany(t => t.GrammarExercises)
                    .Count();
                var completedExercises = _userService.GetCompletedExercisesByLanguage(_currentUser.Id, language.Id);

                double progressPercentage = totalExercises > 0 ? (double)completedExercises / totalExercises * 100 : 0;

                dataGridViewLanguages.Rows.Add(
                    language.Name,
                    completedExercises,
                    totalExercises,
                    $"{progressPercentage:F1}%"
                );
            }
        }

        private void LoadExerciseTypeProgress()
        {
            using var context = new ApplicationDbContext();

            var vocabularyProgress = context.UserProgress
                .Count(p => p.UserId == _currentUser.Id && p.ExerciseType == ExerciseType.Vocabulary && p.Completed);

            var readingProgress = context.UserProgress
                .Count(p => p.UserId == _currentUser.Id && p.ExerciseType == ExerciseType.Reading && p.Completed);

            var grammarProgress = context.UserProgress
                .Count(p => p.UserId == _currentUser.Id && p.ExerciseType == ExerciseType.Grammar && p.Completed);

            var totalVocabulary = context.VocabularyExercises.Count();
            var totalReading = context.ReadingExercises.Count();
            var totalGrammar = context.GrammarExercises.Count();

            UpdateProgressBar(progressBarVocabulary, vocabularyProgress, totalVocabulary);
            UpdateProgressBar(progressBarReading, readingProgress, totalReading);
            UpdateProgressBar(progressBarGrammar, grammarProgress, totalGrammar);

            lblVocabularyProgress.Text = $"{vocabularyProgress}/{totalVocabulary}";
            lblReadingProgress.Text = $"{readingProgress}/{totalReading}";
            lblGrammarProgress.Text = $"{grammarProgress}/{totalGrammar}";
        }

        private void UpdateProgressBar(ProgressBar progressBar, int completed, int total)
        {
            if (progressBar == null) return;

            if (total > 0)
            {
                progressBar.Maximum = total;
                progressBar.Value = completed;

                double percentage = (double)completed / total * 100;
                if (percentage >= 80)
                    progressBar.ForeColor = Color.Green;
                else if (percentage >= 50)
                    progressBar.ForeColor = Color.Orange;
                else
                    progressBar.ForeColor = Color.Red;
            }
            else
            {
                progressBar.Maximum = 1;
                progressBar.Value = 0;
                progressBar.ForeColor = Color.LightGray;
            }
        }

        private void LoadRecentActivities()
        {
            using var context = new ApplicationDbContext();

            var recentActivities = context.UserProgress
                .Where(p => p.UserId == _currentUser.Id)
                .OrderByDescending(p => p.LastAttempt)
                .Take(10)
                .ToList();

            dataGridViewRecent.Rows.Clear();

            foreach (var activity in recentActivities)
            {
                string exerciseType = activity.ExerciseType.ToString();
                string status = activity.Completed ? "Завершено" : "Не завершено";
                string score = activity.Completed ? $"+{activity.Score} балів" : "0 балів";

                dataGridViewRecent.Rows.Add(
                    activity.LastAttempt.ToString("dd.MM.yyyy HH:mm"),
                    exerciseType,
                    $"Вправа #{activity.ExerciseId}",
                    status,
                    score
                );
            }
        }

        private void SetupChart()
        {
            try
            {
                chartProgress.Series.Clear();
                using var context = new ApplicationDbContext();

                var dailyProgress = context.UserProgress
                    .Where(p => p.UserId == _currentUser.Id && p.Completed)
                    .GroupBy(p => p.LastAttempt.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .OrderBy(x => x.Date)
                    .ToList();
                var series = new FastReport.DataVisualization.Charting.Series();
                series.Name = "Прогрес";
                series.ChartType = FastReport.DataVisualization.Charting.SeriesChartType.Column;
                series.Color = ColorTranslator.FromHtml("#B5A972");
                foreach (var day in dailyProgress)
                {
                    var point = new FastReport.DataVisualization.Charting.DataPoint();
                    point.AxisLabel = day.Date.ToString("dd.MM");
                    point.YValues = new double[] { day.Count };
                    series.Points.Add(point);
                }
                chartProgress.Series.Add(series);
                if (chartProgress.ChartAreas.Count > 0)
                {
                    chartProgress.ChartAreas[0].AxisX.Title = "Дата";
                    chartProgress.ChartAreas[0].AxisY.Title = "Кількість вправ";
                    chartProgress.ChartAreas[0].AxisX.Interval = 1;
                }

                if (!dailyProgress.Any())
                {
                    chartProgress.Titles.Clear();
                    var title = new FastReport.DataVisualization.Charting.Title();
                    title.Text = "Ще немає даних для відображення";
                    chartProgress.Titles.Add(title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка налаштування графіка: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProgressData();
            SetupChart();
            MessageBox.Show("Дані оновлено!", "Оновлення",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Текстовий файл (*.txt)|*.txt",
                    FileName = $"прогрес_{_currentUser.Username}_{DateTime.Now:yyyyMMdd}.txt"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportProgressToFile(saveFileDialog.FileName);
                    MessageBox.Show("Дані експортовано успішно!", "Експорт",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка експорту: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportProgressToFile(string filePath)
        {
            using var writer = new System.IO.StreamWriter(filePath);

            writer.WriteLine($"Звіт про прогрес - {_currentUser.Username}");
            writer.WriteLine($"Дата створення: {DateTime.Now:dd.MM.yyyy HH:mm}");
            writer.WriteLine("==========================================");
            writer.WriteLine();

            var stats = _userService.GetUserStats(_currentUser.Id);
            writer.WriteLine($"Загальна статистика:");
            writer.WriteLine($"- Всього вправ: {stats.TotalExercises}");
            writer.WriteLine($"- Виконано вправ: {stats.CompletedExercises}");
            writer.WriteLine($"- Загальний бал: {stats.TotalScore}");
            writer.WriteLine($"- Прогрес: {stats.ProgressPercentage:F1}%");
            writer.WriteLine();
        }
    }
}