using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;

namespace InteractiveLanguageLearning
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private LanguageService _languageService;
        private UserService _userService;

        public MainForm(User user = null)
        {
            InitializeComponent();
            _currentUser = user;
            _languageService = new LanguageService();
            _userService = new UserService();

            LoadLanguages();
            LoadUserStatsForSelectedLanguage();
            cmbLanguages.SelectedIndexChanged += cmbLanguages_SelectedIndexChanged;
        }

        private void LoadLanguages()
        {
            var languages = _languageService.GetAllLanguages();
            cmbLanguages.DataSource = languages;
            cmbLanguages.DisplayMember = "Name";
            cmbLanguages.ValueMember = "Id";

            if (_currentUser?.CurrentLanguageId != null)
            {
                cmbLanguages.SelectedValue = _currentUser.CurrentLanguageId;
            }
            else if (languages.Any())
            {
                cmbLanguages.SelectedIndex = 0;
            }
        }

        private void LoadUserStatsForSelectedLanguage()
        {
            if (_currentUser != null && cmbLanguages.SelectedItem is Language selectedLanguage)
            {
                var stats = GetRealStatsForLanguage(selectedLanguage.Id);
                double progressPercentage = Math.Min(stats.ProgressPercentage, 100.0);

                lblUserStats.Text = $"Мова: {selectedLanguage.Name}\n" +
                                  $"Виконано вправ: {stats.CompletedExercises}/{stats.TotalExercises}\n" +
                                  $"Загальний бал: {stats.TotalScore}\n" +
                                  $"Прогрес: {progressPercentage:F1}%";
            }
            else
            {
                lblUserStats.Text = "Увійдіть для відстеження";
            }
        }

        private UserStats GetRealStatsForLanguage(int languageId)
        {
            using var context = new ApplicationDbContext();

            var totalExercises = context.VocabularyExercises
                .Count(ve => ve.Topic.Section.LanguageId == languageId) +
                context.ReadingExercises
                .Count(re => re.Topic.Section.LanguageId == languageId) +
                context.GrammarExercises
                .Count(ge => ge.Topic.Section.LanguageId == languageId);

            var completedExercises = GetCompletedExercisesCount(context, languageId);
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
            int completedExercises = 0;

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
                completedExercises += context.VocabularyExercises
                    .Where(ve => vocabularyProgress.Contains(ve.Id) &&
                                ve.Topic.Section.LanguageId == languageId)
                    .Count();
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
                completedExercises += context.ReadingExercises
                    .Where(re => readingProgress.Contains(re.Id) &&
                                re.Topic.Section.LanguageId == languageId)
                    .Count();
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
                completedExercises += context.GrammarExercises
                    .Where(ge => grammarProgress.Contains(ge.Id) &&
                                ge.Topic.Section.LanguageId == languageId)
                    .Count();
            }

            return completedExercises;
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

        private void cmbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserStatsForSelectedLanguage();
        }

        private void btnVocabulary_Click(object sender, EventArgs e)
        {
            OpenTopicForm();
        }

        private void OpenTopicForm()
        {
            var selectedLanguage = cmbLanguages.SelectedItem as Language;
            if (selectedLanguage != null && _currentUser != null)
            {
                _currentUser.CurrentLanguageId = selectedLanguage.Id;

                var topicForm = new TopicForm(selectedLanguage, _currentUser);
                topicForm.ShowDialog();
                LoadUserStatsForSelectedLanguage();
            }
            else
            {
                MessageBox.Show("Будь ласка, увійдіть в систему", "Увага",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                var selectedLanguage = cmbLanguages.SelectedItem as Language;
                var progressForm = new ProgressForm(_currentUser, selectedLanguage);
                progressForm.ShowDialog();
                LoadUserStatsForSelectedLanguage();
            }
            else
            {
                MessageBox.Show("Будь ласка, увійдіть в систему для перегляду прогресу",
                              "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                _currentUser = loginForm.AuthenticatedUser;
                LoadLanguages();
                LoadUserStatsForSelectedLanguage();

                if (_currentUser != null)
                {
                    Console.WriteLine($"User: {_currentUser.Username}");
                    Console.WriteLine($"Role: {_currentUser.Role?.Name}");
                    Console.WriteLine($"IsTeacher: {_currentUser.IsTeacher}");

                    btnTeacherPanel.Visible = _currentUser.IsTeacher;
                    Console.WriteLine($"Teacher panel button visible: {btnTeacherPanel.Visible}");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                _currentUser = registerForm.RegisteredUser;
                LoadLanguages();
                LoadUserStatsForSelectedLanguage();
            }
        }

        private void btnTeacherPanel_Click(object sender, EventArgs e)
        {
            if (_currentUser != null && _currentUser.IsTeacher)
            {
                var teacherPanel = new TeacherPanelForm(_currentUser);
                teacherPanel.ShowDialog();
            }
            else
            {
                MessageBox.Show("Доступ заборонено. Необхідні права вчителя.", "Доступ заборонено",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    // Допоміжний клас для статистики
    public class UserStats
    {
        public int TotalExercises { get; set; }
        public int CompletedExercises { get; set; }
        public int TotalScore { get; set; }
        public double ProgressPercentage { get; set; }
    }
}