using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InteractiveLanguageLearning
{
    public partial class ProgressForm : Form
    {
        private User _currentUser;
        private Language _selectedLanguage;
        private UserService _userService;
        private LanguageService _languageService;

        public ProgressForm(User user, Language selectedLanguage)
        {
            InitializeComponent();
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _selectedLanguage = selectedLanguage ?? throw new ArgumentNullException(nameof(selectedLanguage));
            _userService = new UserService();
            _languageService = new LanguageService();

            this.Text = $"Прогрес - {_selectedLanguage.Name}";

            LoadProgressData();
            SetupChart();
        }

        private void LoadProgressData()
        {
            if (_currentUser == null) return;

            try
            {
                var stats = GetRealStatsForLanguage(_selectedLanguage.Id);
                double progressPercentage = Math.Min(stats.ProgressPercentage, 100.0);

                lblTotalExercises.Text = stats.TotalExercises.ToString();
                lblCompletedExercises.Text = stats.CompletedExercises.ToString();
                lblTotalScore.Text = stats.TotalScore.ToString();
                lblProgressPercentage.Text = $"{progressPercentage:F1}%";

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

        private UserStats GetRealStatsForLanguage(int languageId)
        {
            using var context = new ApplicationDbContext();

            // Отримуємо реальну кількість унікальних вправ для мови
            var totalExercises = context.VocabularyExercises
                .Count(ve => ve.Topic.Section.LanguageId == languageId) +
                context.ReadingExercises
                .Count(re => re.Topic.Section.LanguageId == languageId) +
                context.GrammarExercises
                .Count(ge => ge.Topic.Section.LanguageId == languageId);

            // Отримуємо кількість унікальних виконаних вправ
            var completedExercises = GetCompletedExercisesCount(context, languageId);

            // Загальний бал (спрощена версія)
            var totalScore = CalculateScoreForUniqueExercises(context, languageId);

            double progressPercentage = totalExercises > 0 ?
                Math.Min((double)completedExercises / totalExercises * 100, 100.0) : 0;

            return new UserStats
            {
                TotalExercises = totalExercises,
                CompletedExercises = completedExercises,
                TotalScore = totalScore,
                ProgressPercentage = progressPercentage
            };
        }

        private int GetCompletedExercisesCount(ApplicationDbContext context, int languageId)
        {
            // Отримуємо всі унікальні ID виконаних вправ для кожної категорії
            var vocabularyIds = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id && up.Completed && up.ExerciseType == ExerciseType.Vocabulary)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            var readingIds = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id && up.Completed && up.ExerciseType == ExerciseType.Reading)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            var grammarIds = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id && up.Completed && up.ExerciseType == ExerciseType.Grammar)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            // Фільтруємо по мові
            var completedVocabulary = context.VocabularyExercises
                .Where(ve => vocabularyIds.Contains(ve.Id) && ve.Topic.Section.LanguageId == languageId)
                .Count();

            var completedReading = context.ReadingExercises
                .Where(re => readingIds.Contains(re.Id) && re.Topic.Section.LanguageId == languageId)
                .Count();

            var completedGrammar = context.GrammarExercises
                .Where(ge => grammarIds.Contains(ge.Id) && ge.Topic.Section.LanguageId == languageId)
                .Count();

            return completedVocabulary + completedReading + completedGrammar;
        }

        private int CalculateScoreForUniqueExercises(ApplicationDbContext context, int languageId)
        {
            int totalScore = 0;

            // Для словникових вправ
            var vocabularyProgress = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id &&
                           up.Completed &&
                           up.ExerciseType == ExerciseType.Vocabulary)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            if (vocabularyProgress.Any())
            {
                var vocabularyExercises = context.VocabularyExercises
                    .Where(ve => vocabularyProgress.Contains(ve.Id) &&
                                ve.Topic.Section.LanguageId == languageId)
                    .Select(ve => ve.Id)
                    .ToList();

                totalScore += vocabularyExercises.Count * 10;
            }

            // Для вправ з читання
            var readingProgress = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id &&
                           up.Completed &&
                           up.ExerciseType == ExerciseType.Reading)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            if (readingProgress.Any())
            {
                var readingExercises = context.ReadingExercises
                    .Where(re => readingProgress.Contains(re.Id) &&
                                re.Topic.Section.LanguageId == languageId)
                    .Select(re => re.Id)
                    .ToList();

                totalScore += readingExercises.Count * 10;
            }

            // Для граматичних вправ
            var grammarProgress = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id &&
                           up.Completed &&
                           up.ExerciseType == ExerciseType.Grammar)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            if (grammarProgress.Any())
            {
                var grammarExercises = context.GrammarExercises
                    .Where(ge => grammarProgress.Contains(ge.Id) &&
                                ge.Topic.Section.LanguageId == languageId)
                    .Select(ge => ge.Id)
                    .ToList();

                totalScore += grammarExercises.Count * 10;
            }

            return totalScore;
        }

        private void LoadLanguageProgress()
        {
            using var context = new ApplicationDbContext();
            var languages = _languageService.GetAllLanguages();
            dataGridViewLanguages.Rows.Clear();

            foreach (var language in languages)
            {
                var stats = GetRealStatsForLanguage(language.Id);

                dataGridViewLanguages.Rows.Add(
                    language.Name,
                    stats.CompletedExercises,
                    stats.TotalExercises,
                    $"{Math.Min(stats.ProgressPercentage, 100.0):F1}%"
                );
            }
        }

        private void LoadExerciseTypeProgress()
        {
            using var context = new ApplicationDbContext();

            // Спрощена версія без складних JOIN
            var vocabularyProgress = GetExerciseTypeProgressCount(context, ExerciseType.Vocabulary);
            var readingProgress = GetExerciseTypeProgressCount(context, ExerciseType.Reading);
            var grammarProgress = GetExerciseTypeProgressCount(context, ExerciseType.Grammar);

            var totalVocabulary = context.VocabularyExercises
                .Count(ve => ve.Topic.Section.LanguageId == _selectedLanguage.Id);
            var totalReading = context.ReadingExercises
                .Count(re => re.Topic.Section.LanguageId == _selectedLanguage.Id);
            var totalGrammar = context.GrammarExercises
                .Count(ge => ge.Topic.Section.LanguageId == _selectedLanguage.Id);

            UpdateProgressBar(progressBarVocabulary, vocabularyProgress, totalVocabulary);
            UpdateProgressBar(progressBarReading, readingProgress, totalReading);
            UpdateProgressBar(progressBarGrammar, grammarProgress, totalGrammar);
        }

        private int GetExerciseTypeProgressCount(ApplicationDbContext context, ExerciseType exerciseType)
        {
            // Отримуємо всі унікальні ID виконаних вправ для даного типу
            var completedIds = context.UserProgress
                .Where(up => up.UserId == _currentUser.Id && up.Completed && up.ExerciseType == exerciseType)
                .Select(up => up.ExerciseId)
                .Distinct()
                .ToList();

            // Фільтруємо по мові
            return exerciseType switch
            {
                ExerciseType.Vocabulary => context.VocabularyExercises
                    .Where(ve => completedIds.Contains(ve.Id) && ve.Topic.Section.LanguageId == _selectedLanguage.Id)
                    .Count(),
                ExerciseType.Reading => context.ReadingExercises
                    .Where(re => completedIds.Contains(re.Id) && re.Topic.Section.LanguageId == _selectedLanguage.Id)
                    .Count(),
                ExerciseType.Grammar => context.GrammarExercises
                    .Where(ge => completedIds.Contains(ge.Id) && ge.Topic.Section.LanguageId == _selectedLanguage.Id)
                    .Count(),
                _ => 0
            };
        }

        private void UpdateProgressBar(ProgressBar progressBar, int completed, int total)
        {
            if (progressBar == null) return;

            try
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = total > 0 ? total : 1;

                int safeValue = Math.Max(0, Math.Min(completed, progressBar.Maximum));
                progressBar.Value = safeValue;

                double percentage = total > 0 ? Math.Min((double)safeValue / total * 100, 100.0) : 0;
                if (percentage >= 80)
                    progressBar.ForeColor = Color.FromArgb(123, 198, 200);
                else if (percentage >= 50)
                    progressBar.ForeColor = Color.Orange;
                else
                    progressBar.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка оновлення ProgressBar: {ex.Message}");
                progressBar.Maximum = 1;
                progressBar.Value = 0;
                progressBar.ForeColor = Color.LightGray;
            }
        }

        private void LoadRecentActivities()
        {
            using var context = new ApplicationDbContext();

            try
            {
                // Спрощена версія - отримуємо всі активності і фільтруємо в пам'яті
                var allActivities = context.UserProgress
                    .Where(up => up.UserId == _currentUser.Id)
                    .OrderByDescending(up => up.LastAttempt)
                    .Take(50)
                    .ToList();

                var recentActivities = new List<dynamic>();

                // Для словникових вправ
                foreach (var activity in allActivities.Where(a => a.ExerciseType == ExerciseType.Vocabulary))
                {
                    var exercise = context.VocabularyExercises
                        .Include(ve => ve.Topic)
                        .ThenInclude(t => t.Section)
                        .FirstOrDefault(ve => ve.Id == activity.ExerciseId);

                    if (exercise?.Topic?.Section?.LanguageId == _selectedLanguage.Id)
                    {
                        recentActivities.Add(new
                        {
                            activity.LastAttempt,
                            activity.ExerciseType,
                            activity.ExerciseId,
                            activity.Completed,
                            activity.Score
                        });
                    }
                }

                // Для вправ з читання
                foreach (var activity in allActivities.Where(a => a.ExerciseType == ExerciseType.Reading))
                {
                    var exercise = context.ReadingExercises
                        .Include(re => re.Topic)
                        .ThenInclude(t => t.Section)
                        .FirstOrDefault(re => re.Id == activity.ExerciseId);

                    if (exercise?.Topic?.Section?.LanguageId == _selectedLanguage.Id)
                    {
                        recentActivities.Add(new
                        {
                            activity.LastAttempt,
                            activity.ExerciseType,
                            activity.ExerciseId,
                            activity.Completed,
                            activity.Score
                        });
                    }
                }

                // Для граматичних вправ
                foreach (var activity in allActivities.Where(a => a.ExerciseType == ExerciseType.Grammar))
                {
                    var exercise = context.GrammarExercises
                        .Include(ge => ge.Topic)
                        .ThenInclude(t => t.Section)
                        .FirstOrDefault(ge => ge.Id == activity.ExerciseId);

                    if (exercise?.Topic?.Section?.LanguageId == _selectedLanguage.Id)
                    {
                        recentActivities.Add(new
                        {
                            activity.LastAttempt,
                            activity.ExerciseType,
                            activity.ExerciseId,
                            activity.Completed,
                            activity.Score
                        });
                    }
                }

                // Сортуємо і обмежуємо кількість
                var finalActivities = recentActivities
                    .OrderByDescending(x => x.LastAttempt)
                    .Take(10)
                    .ToList();

                dataGridViewRecent.Rows.Clear();

                foreach (var activity in finalActivities)
                {
                    string exerciseType = GetExerciseTypeDisplayName(activity.ExerciseType);
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

                if (!finalActivities.Any())
                {
                    dataGridViewRecent.Rows.Add("Немає останніх активностей", "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження останніх активностей: {ex.Message}");
                dataGridViewRecent.Rows.Clear();
                dataGridViewRecent.Rows.Add("Помилка завантаження даних", "", "", "", "");
            }
        }

        private string GetExerciseTypeDisplayName(ExerciseType exerciseType)
        {
            return exerciseType switch
            {
                ExerciseType.Vocabulary => "Словниковий запас",
                ExerciseType.Reading => "Читання",
                ExerciseType.Grammar => "Граматика",
                _ => exerciseType.ToString()
            };
        }

        private void SetupChart()
        {
            try
            {
                chartProgress.Series.Clear();
                chartProgress.Titles.Clear();

                using var context = new ApplicationDbContext();

                // Проста версія графіка - без фільтрації по мові
                var dailyProgress = context.UserProgress
                    .Where(up => up.UserId == _currentUser.Id && up.Completed)
                    .GroupBy(up => up.LastAttempt.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .OrderBy(x => x.Date)
                    .ToList();

                if (dailyProgress.Any())
                {
                    chartProgress.Series.Add("Прогрес");
                    var series = chartProgress.Series["Прогрес"];
                    series.ChartType = FastReport.DataVisualization.Charting.SeriesChartType.Column;
                    series.Color = ColorTranslator.FromHtml("#F22233");

                    foreach (var day in dailyProgress)
                    {
                        series.Points.AddXY(day.Date.ToString("dd.MM"), day.Count);
                    }

                    if (chartProgress.ChartAreas.Count > 0)
                    {
                        chartProgress.ChartAreas[0].AxisX.Title = "Дата";
                        chartProgress.ChartAreas[0].AxisY.Title = "Кількість вправ";
                        chartProgress.ChartAreas[0].AxisX.Interval = 1;
                        chartProgress.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    }
                }
                else
                {
                    var title = new FastReport.DataVisualization.Charting.Title();
                    title.Text = "Ще немає даних для відображення";
                    title.Font = new Font("Arial", 12, FontStyle.Bold);
                    title.ForeColor = Color.Gray;
                    chartProgress.Titles.Add(title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка налаштування графіка: {ex.Message}");
                chartProgress.Titles.Clear();
                var errorTitle = new FastReport.DataVisualization.Charting.Title();
                errorTitle.Text = "Помилка завантаження графіка";
                errorTitle.Font = new Font("Arial", 10, FontStyle.Bold);
                errorTitle.ForeColor = Color.Red;
                chartProgress.Titles.Add(errorTitle);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Текстовий файл (*.txt)|*.txt",
                    FileName = $"прогрес_{_currentUser.Username}_{_selectedLanguage.Name}_{DateTime.Now:yyyyMMdd}.txt"
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
            writer.WriteLine($"Мова: {_selectedLanguage.Name}");
            writer.WriteLine($"Дата створення: {DateTime.Now:dd.MM.yyyy HH:mm}");
            writer.WriteLine("==========================================");
            writer.WriteLine();

            var stats = GetRealStatsForLanguage(_selectedLanguage.Id);
            double progressPercentage = Math.Min(stats.ProgressPercentage, 100.0);

            writer.WriteLine($"Загальна статистика для мови {_selectedLanguage.Name}:");
            writer.WriteLine($"- Всього вправ: {stats.TotalExercises}");
            writer.WriteLine($"- Виконано вправ: {stats.CompletedExercises}");
            writer.WriteLine($"- Загальний бал: {stats.TotalScore}");
            writer.WriteLine($"- Прогрес: {progressPercentage:F1}%");
            writer.WriteLine();

            writer.WriteLine("Прогрес по мовах:");
            var languages = _languageService.GetAllLanguages();

            foreach (var language in languages)
            {
                var langStats = GetRealStatsForLanguage(language.Id);
                writer.WriteLine($"- {language.Name}: {langStats.CompletedExercises}/{langStats.TotalExercises} ({Math.Min(langStats.ProgressPercentage, 100.0):F1}%)");
            }
        }

        private void dataGridViewLanguages_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewLanguages.ClearSelection();
        }

        private void dataGridViewRecent_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewRecent.ClearSelection();
        }
    }
}