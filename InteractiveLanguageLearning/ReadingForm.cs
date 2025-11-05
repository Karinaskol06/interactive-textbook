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

        public ReadingForm(Language language, User? user, int? topicId = null) : base(language, user)
        {
            InitializeComponent();
            _exerciseService = new ExerciseService();
            LoadExercises(topicId);

            if (_exercises.Length > 0)
            {
                LoadNextExercise();
            }
            else
            {
                MessageBox.Show("Не знайдено вправ з читання для обраної теми", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        public ReadingForm(Language language, User? user) : this(language, user, null) { }

        private void LoadExercises(int? topicId = null)
        {
            if (_language?.Sections == null) return;

            try
            {
                var topics = _language.Sections
                    .Where(s => s.Name == "Читання")
                    .SelectMany(s => s.Topics)
                    .ToList();
                if (topicId.HasValue)
                {
                    topics = topics.Where(t => t.Id == topicId.Value).ToList();
                }

                _exercises = topics
                    .SelectMany(t => _exerciseService.GetReadingExercisesByTopic(t.Id))
                    .ToArray();

                Console.WriteLine($"Завантажено {_exercises.Length} вправ з читання" +
                                 (topicId.HasValue ? $" для теми ID: {topicId}" : ""));
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

                    // Додаємо перенос на новий рядок для питання
                    lblQuestion.Text = _currentExercise.Question;
                    lblQuestion.AutoSize = true;
                    lblQuestion.MaximumSize = new Size(panelQuestion.Width - 20, 0); // Дозволяє автоматичний перенос

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

            if (isCorrect)
            {
                // Правильна відповідь - зберігаємо прогрес і переходимо до наступної вправи
                SaveProgress(_currentExercise.Id, ExerciseType.Reading, true);

                string message = $"Правильно!\n\n{_currentExercise.Explanation}";
                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _currentExerciseIndex++;
                LoadNextExercise();
            }
            else
            {
                // Неправильна відповідь - показуємо помилку і залишаємо на цій же вправі
                string message = $"Неправильно. Спробуйте ще раз!\n\n" +
                               $"Підказка: {_currentExercise.Explanation}";
                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Скидаємо вибір для нової спроби
                ResetRadioButtons();
                btnNext.Enabled = false;
            }
        }

        private void ResetRadioButtons()
        {
            foreach (Control control in panelQuestion.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
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

        // Додатковий метод для обробки зміни розміру форми
        private void ReadingForm_Resize(object sender, EventArgs e)
        {
            // Оновлюємо максимальну ширину для переносу тексту при зміні розміру форми
            if (lblQuestion != null)
            {
                lblQuestion.MaximumSize = new Size(panelQuestion.Width - 20, 0);
            }
        }
    }
}