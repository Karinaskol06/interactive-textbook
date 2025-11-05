using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class VocabularyForm : BaseExerciseForm
    {
        private ExerciseService _exerciseService;
        private VocabularyExercise? _currentExercise;
        private int _currentExerciseIndex = 0;
        private VocabularyExercise[] _exercises = Array.Empty<VocabularyExercise>();

        public VocabularyForm(Language language, User? user, int? topicId = null) : base(language, user)
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
                MessageBox.Show("Не знайдено вправ зі словникового запасу для обраної теми", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public VocabularyForm(Language language, User? user) : this(language, user, null) { }

        private void LoadExercises(int? topicId = null)
        {
            if (_language?.Sections == null)
            {
                MessageBox.Show("Не вдалося завантажити дані про мову", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var topics = _language.Sections
                    .Where(s => s.Name == "Словниковий запас")
                    .SelectMany(s => s.Topics)
                    .ToList();

                if (topicId.HasValue)
                {
                    topics = topics.Where(t => t.Id == topicId.Value).ToList();
                }

                if (!topics.Any())
                {
                    MessageBox.Show("Не знайдено тем для словникового запасу", "Інформація",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var allExercises = new List<VocabularyExercise>();
                foreach (var topic in topics)
                {
                    var exercises = _exerciseService.GetVocabularyExercisesByTopic(topic.Id);
                    if (exercises != null)
                    {
                        allExercises.AddRange(exercises);
                    }
                }

                _exercises = allExercises.ToArray();
                Console.WriteLine($"Завантажено {_exercises.Length} вправ зі словникового запасу" +
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
            if (_exercises == null || _exercises.Length == 0)
            {
                MessageBox.Show("Немає доступних вправ", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            if (_currentExerciseIndex < _exercises.Length)
            {
                _currentExercise = _exercises[_currentExerciseIndex];

                if (_currentExercise != null)
                {
                    lblQuestion.Text = _currentExercise.Question ?? "Питання відсутнє";
                    var options = _currentExercise.GetOptionsList();
                    for (int i = 0; i < options.Count && i < 4; i++)
                    {
                        var radioButton = this.Controls.Find($"radioOption{i + 1}", true).FirstOrDefault() as RadioButton;
                        if (radioButton != null)
                        {
                            radioButton.Text = options[i] ?? "Варіант відповіді";
                            radioButton.Checked = false;
                            radioButton.Visible = true;
                            radioButton.Enabled = true;
                        }
                    }
                    for (int i = options.Count; i < 4; i++)
                    {
                        var radioButton = this.Controls.Find($"radioOption{i + 1}", true).FirstOrDefault() as RadioButton;
                        if (radioButton != null)
                        {
                            radioButton.Visible = false;
                        }
                    }
                    lblProgress.Text = $"Питання {_currentExerciseIndex + 1} з {_exercises.Length}";
                    btnNext.Enabled = false;
                    LoadWordImage();
                }
            }
            else
            {
                MessageBox.Show("Вітаємо! Ви завершили всі вправи зі словникового запасу.", "Завершено",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void LoadWordImage()
        {
            pbWordImage.Visible = true;

            if (string.IsNullOrEmpty(_currentExercise?.ImagePath))
            {
                pbWordImage.Image = null;
                return;
            }
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images", "Vocabulary");
                string imagePath = Path.Combine(imagesFolder, _currentExercise.ImagePath);

                if (File.Exists(imagePath))
                {
                    pbWordImage.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pbWordImage.Image = null;
                    Console.WriteLine($"Картинка не знайдена: {imagePath}");
                }
            }
            catch (Exception ex)
            {
                pbWordImage.Image = null;
                Console.WriteLine($"Помилка завантаження картинки: {ex.Message}");
            }
        }

        private void radioOption_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentExercise == null)
            {
                Console.WriteLine("btnNext: _currentExercise is NULL");
                return;
            }

            var selectedOption = GetSelectedOption();
            if (string.IsNullOrEmpty(selectedOption))
            {
                MessageBox.Show("Будь ласка, оберіть варіант відповіді", "Увага",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isCorrect = selectedOption == _currentExercise.CorrectAnswer;
            Console.WriteLine($"User selected: {selectedOption}, Correct: {_currentExercise.CorrectAnswer}, IsCorrect: {isCorrect}");

            if (isCorrect)
            {
                SaveProgress(_currentExercise.Id, ExerciseType.Vocabulary, true);

                string message = $"Правильно!\n{_currentExercise.Explanation}";
                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _currentExerciseIndex++;
                LoadNextExercise();
            }
            else
            {
                string message = $"Неправильно. Спробуйте ще раз!\nПідказка: {_currentExercise.Explanation}";
                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ResetRadioButtons();
                btnNext.Enabled = false;
            }
        }

        private void ResetRadioButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        if (childControl is RadioButton radioButton)
                        {
                            radioButton.Checked = false;
                        }
                    }
                }
            }
        }

        private string? GetSelectedOption()
        {
            foreach (Control control in this.Controls)
            {
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        if (childControl is RadioButton childRadio && childRadio.Checked)
                        {
                            return childRadio.Text;
                        }
                    }
                }
            }
            return null;
        }
    }
}