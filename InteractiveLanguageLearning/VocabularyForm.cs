using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
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

        public VocabularyForm(Language language, User? user) : base(language, user)
        {
            InitializeComponent();
            _exerciseService = new ExerciseService(); 
            LoadExercises();
            if (_exercises.Length > 0)
            {
                LoadNextExercise();
            }
            else
            {
                MessageBox.Show("Не знайдено вправ зі словникового запасу", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void LoadExercises()
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
                Console.WriteLine($"Завантажено {_exercises.Length} вправ зі словникового запасу");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження вправ: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Деталі помилки: {ex}");
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
                }
            }
            else
            {
                MessageBox.Show("Вітаємо! Ви завершили всі вправи зі словникового запасу.", "Завершено",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
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

            SaveProgress(_currentExercise.Id, ExerciseType.Vocabulary, isCorrect);

            string message = isCorrect ?
                "Правильно! " + _currentExercise.Explanation :
                $"Неправильно. Правильна відповідь: {_currentExercise.CorrectAnswer}\n{_currentExercise.Explanation}";

            MessageBox.Show(message, "Результат", MessageBoxButtons.OK,
                          isCorrect ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            _currentExerciseIndex++;
            LoadNextExercise();
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