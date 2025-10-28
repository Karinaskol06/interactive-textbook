using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;

namespace InteractiveLanguageLearning
{
    public partial class ReadingForm : BaseExerciseForm
    {
        private ExerciseService _exerciseService;
        private ReadingExercise _currentExercise;
        private int _currentExerciseIndex = 0;
        private ReadingExercise[] _exercises = Array.Empty<ReadingExercise>();

        public ReadingForm(Language language, User? user) : base(language, user)
        {
            InitializeComponent();
            _exerciseService = new ExerciseService();
            LoadExercises();
            LoadNextExercise();
        }

        private void LoadExercises()
        {
            if (_language?.Sections == null) return;

            try
            {
                var topics = _language.Sections
                    .Where(s => s.Name == "Читання")
                    .SelectMany(s => s.Topics)
                    .ToList();

                _exercises = topics
                    .SelectMany(t => _exerciseService.GetReadingExercisesByTopic(t.Id))
                    .ToArray();

                Console.WriteLine($"Loaded {_exercises.Length} reading exercises");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження вправ: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNextExercise()
        {
            if (_currentExerciseIndex < _exercises.Length)
            {
                _currentExercise = _exercises[_currentExerciseIndex];

                if (_currentExercise != null)
                {
                    lblTitle.Text = _currentExercise.Title;
                    txtReadingText.Text = _currentExercise.TextContent;
                    lblQuestion.Text = _currentExercise.Question;
                    var options = _currentExercise.GetOptionsList();
                    for (int i = 0; i < options.Count && i < 4; i++)
                    {
                        var radioButton = panelQuestion.Controls.Find($"radioOption{i + 1}", false).FirstOrDefault() as RadioButton;
                        if (radioButton != null)
                        {
                            radioButton.Text = options[i];
                            radioButton.Checked = false;
                            radioButton.Visible = true;
                        }
                    }
                    for (int i = options.Count; i < 4; i++)
                    {
                        var radioButton = panelQuestion.Controls.Find($"radioOption{i + 1}", false).FirstOrDefault() as RadioButton;
                        if (radioButton != null)
                        {
                            radioButton.Visible = false;
                        }
                    }

                    lblProgress.Text = $"Вправа {_currentExerciseIndex + 1} з {_exercises.Length}";
                    btnNext.Enabled = false;
                    txtReadingText.SelectionStart = 0;
                    txtReadingText.ScrollToCaret();
                }
            }
            else
            {
                MessageBox.Show("Вітаємо! Ви завершили всі вправи з читання.", "Завершено",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void radioOption_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentExercise == null) return;

            var selectedOption = GetSelectedOption();
            if (string.IsNullOrEmpty(selectedOption))
            {
                MessageBox.Show("Будь ласка, оберіть варіант відповіді", "Увага",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isCorrect = selectedOption == _currentExercise.CorrectAnswer;
            SaveProgress(_currentExercise.Id, ExerciseType.Reading, isCorrect);
            ShowResult(isCorrect, selectedOption);

            _currentExerciseIndex++;
            LoadNextExercise();
        }

        private void ShowResult(bool isCorrect, string selectedOption)
        {
            string message;
            MessageBoxIcon icon;

            if (isCorrect)
            {
                message = $"Правильно!\n\n{_currentExercise.Explanation}";
                icon = MessageBoxIcon.Information;
            }
            else
            {
                message = $"Неправильно.\n\n" +
                         $"Ваша відповідь: {selectedOption}\n" +
                         $"Правильна відповідь: {_currentExercise.CorrectAnswer}\n\n" +
                         $"{_currentExercise.Explanation}";
                icon = MessageBoxIcon.Warning;
            }

            MessageBox.Show(message, "Результат", MessageBoxButtons.OK, icon);
        }

        private string GetSelectedOption()
        {
            foreach (Control control in panelQuestion.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    return radio.Text;
                }
            }
            return null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReadingText_TextChanged(object sender, EventArgs e)
        {
            // Можна додати додаткову логіку, якщо потрібно
        }
    }
}