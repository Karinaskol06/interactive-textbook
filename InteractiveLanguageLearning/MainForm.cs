using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            LoadUserStats();
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

        private void LoadUserStats()
        {
            if (_currentUser != null)
            {
                var stats = _userService.GetUserStats(_currentUser.Id);
                lblUserStats.Text = $"Виконано вправ: {stats.CompletedExercises}/{stats.TotalExercises}\n" +
                                  $"Загальний бал: {stats.TotalScore}\n" +
                                  $"Прогрес: {stats.ProgressPercentage:F1}%";
            }
            else
            {
                lblUserStats.Text = "Увійдіть для відстеження прогресу";
            }
        }

        private void btnVocabulary_Click(object sender, EventArgs e)
        {
            var selectedLanguage = cmbLanguages.SelectedItem as Language;
            if (selectedLanguage != null && _currentUser != null)
            {
                var userService = new UserService();
                if (_currentUser.CurrentLanguageId != selectedLanguage.Id)
                {
                    _currentUser.CurrentLanguageId = selectedLanguage.Id;
                }

                var vocabularyForm = new VocabularyForm(selectedLanguage, _currentUser);
                vocabularyForm.ShowDialog();
                LoadUserStats();
            }
            else
            {
                MessageBox.Show("Будь ласка, увійдіть в систему", "Увага",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReading_Click(object sender, EventArgs e)
        {
            var selectedLanguage = cmbLanguages.SelectedItem as Language;
            if (selectedLanguage != null && _currentUser != null)
            {
                var readingForm = new ReadingForm(selectedLanguage, _currentUser);
                readingForm.ShowDialog();
                LoadUserStats();
            }
            else
            {
                MessageBox.Show("Будь ласка, увійдіть в систему", "Увага",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrammar_Click(object sender, EventArgs e)
        {
            var selectedLanguage = (Language)cmbLanguages.SelectedItem;
            var grammarForm = new GrammarForm(selectedLanguage, _currentUser);
            grammarForm.ShowDialog();
            LoadUserStats();
        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                var progressForm = new ProgressForm(_currentUser);
                progressForm.ShowDialog();
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
                LoadUserStats();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                _currentUser = registerForm.RegisteredUser;
                LoadUserStats();
            }
        }
    }
}