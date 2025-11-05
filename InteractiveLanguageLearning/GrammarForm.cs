using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class GrammarForm : BaseExerciseForm
    {
        private ExerciseService _exerciseService;
        private GrammarExercise _currentExercise;
        private int _currentExerciseIndex = 0;
        private GrammarExercise[] _exercises = Array.Empty<GrammarExercise>();
        private List<Label> _dragLabels = new List<Label>();
        private List<Panel> _dropPanels = new List<Panel>();
        private Label _draggedLabel = null;

        public GrammarForm(Language language, User? user, int? topicId = null) : base(language, user)
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
                MessageBox.Show("Не знайдено вправ з граматики для обраної теми", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public GrammarForm(Language language, User? user) : this(language, user, null) { }

        private void LoadExercises(int? topicId = null)
        {
            try
            {
                var topics = _language.Sections
                    .Where(s => s.Name == "Граматика")
                    .SelectMany(s => s.Topics)
                    .ToList();

                if (topicId.HasValue)
                {
                    topics = topics.Where(t => t.Id == topicId.Value).ToList();
                }

                var allExercises = new List<GrammarExercise>();
                foreach (var topic in topics)
                {
                    var exercises = _exerciseService.GetGrammarExercisesByTopic(topic.Id);
                    if (exercises != null)
                    {
                        allExercises.AddRange(exercises);
                    }
                }
                _exercises = allExercises.ToArray();

                Console.WriteLine($"Завантажено {_exercises.Length} вправ з граматики" +
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
                    ClearExerciseElements();
                    lblTitle.Text = _currentExercise.Title ?? "Вправа з граматики";
                    lblExplanation.Text = _currentExercise.Explanation ?? "Пояснення відсутнє";
                    if (IsDragAndDropExercise(_currentExercise))
                    {
                        LoadDragAndDropExercise();
                    }
                    else if (IsFillInTheBlanksExercise(_currentExercise))
                    {
                        LoadFillInTheBlanksExercise();
                    }
                    else
                    {
                        LoadMultipleChoiceExercise();
                    }

                    lblProgress.Text = $"Вправа {_currentExerciseIndex + 1} з {_exercises.Length}";
                    btnCheckAnswer.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Вітаємо! Ви завершили всі вправи з граматики.", "Завершено",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool IsFillInTheBlanksExercise(GrammarExercise exercise)
        {
            if (exercise.Example == null) return false;
            var correctAnswers = exercise.CorrectAnswer?.Split(',');
            if (correctAnswers != null && correctAnswers.Length > 1)
            {
                return true;
            }
            return exercise.Example.Contains("___") ||
                   exercise.Example.Contains(" _ ") ||
                   (exercise.Example.Contains("(") && exercise.Example.Contains(")"));
        }

        private bool IsDragAndDropExercise(GrammarExercise exercise)
        {
            return exercise.Example != null && exercise.Example.Contains("[") && exercise.Example.Contains("]");
        }

        private void LoadDragAndDropExercise()
        {
            panelFillInTheBlanks.Visible = false;
            panelDragDrop.Visible = true;
            panelMultipleChoice.Visible = false;
            lblDragDropTitle.Text = _currentExercise.Question ?? "Перетягніть правильні слова";
            LoadDragAndDropControls();
        }

        private void LoadDragAndDropControls()
        {
            panelDragLabels.Controls.Clear();
            _dragLabels.Clear();
            _dropPanels.Clear();
            panelDragLabels.Visible = true;

            panelDragLabels.Location = new Point(20, 60); 
            panelDragLabels.Size = new Size(panelDragDrop.Width - 40, 100); 
            panelDragLabels.BorderStyle = BorderStyle.FixedSingle;
            panelDragLabels.BackColor = ColorTranslator.FromHtml("#77a19f");
            panelDragLabels.Padding = new Padding(10);

            var example = _currentExercise.Example;
            var options = _currentExercise.GetOptionsList();
            var correctAnswers = _currentExercise.CorrectAnswer.Split(',');

            int xPos = 10;
            int yPos = 10;

            foreach (var option in options)
            {
                var dragLabel = new Label
                {
                    Text = option.Trim(),
                    BackColor = ColorTranslator.FromHtml("#99d1ce"),
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoSize = true,
                    Location = new Point(xPos, yPos),
                    Padding = new Padding(5),
                    Cursor = Cursors.Hand,
                    Tag = option.Trim(),
                    Font = new Font("Sitka Text", 10F)
                };

                dragLabel.MouseDown += DragLabel_MouseDown;
                panelDragLabels.Controls.Add(dragLabel);
                _dragLabels.Add(dragLabel);

                xPos += dragLabel.Width + 10;
                if (xPos > panelDragLabels.Width - 100)
                {
                    xPos = 10;
                    yPos += 35;
                }
            }

            var sentenceParts = example.Split('[', ']');
            int startXPos = 20; 
            int startYPos = panelDragLabels.Bottom + 30; 
            int currentXPos = startXPos;
            int currentYPos = startYPos;

            int maxWidth = (panelDragDrop.Width - 60); 
            int currentSentenceWidth = 0;
            bool isNewLine = true;

            for (int i = 0; i < sentenceParts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (!string.IsNullOrEmpty(sentenceParts[i].Trim()))
                    {
                        var testLabel = new Label
                        {
                            Text = sentenceParts[i],
                            AutoSize = true,
                            Font = new Font("Sitka Text", 10F)
                        };
                        if (isNewLine || currentSentenceWidth + testLabel.Width > maxWidth)
                        {
                            currentXPos = startXPos;
                            if (!isNewLine) 
                            {
                                currentYPos += 40;
                            }
                            currentSentenceWidth = 0;
                            isNewLine = false;
                        }

                        var label = new Label
                        {
                            Text = sentenceParts[i],
                            AutoSize = true,
                            Location = new Point(currentXPos, currentYPos),
                            Font = new Font("Sitka Text", 10F)
                        };
                        panelDragDrop.Controls.Add(label);
                        currentXPos += label.Width + 5;
                        currentSentenceWidth += label.Width + 5;
                    }
                }
                else
                {
                    var dropPanelWidth = 80;
                    if (currentSentenceWidth + dropPanelWidth > maxWidth && !isNewLine)
                    {
                        currentXPos = startXPos;
                        currentYPos += 40;
                        currentSentenceWidth = 0;
                    }

                    var dropPanel = new Panel
                    {
                        Size = new Size(dropPanelWidth, 30),
                        Location = new Point(currentXPos, currentYPos - 5),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = ColorTranslator.FromHtml("#99d1ce"),
                        AllowDrop = true,
                        Tag = correctAnswers[_dropPanels.Count].Trim()
                    };
                    dropPanel.DragEnter += DropPanel_DragEnter;
                    dropPanel.DragDrop += DropPanel_DragDrop;
                    panelDragDrop.Controls.Add(dropPanel);
                    _dropPanels.Add(dropPanel);
                    currentXPos += dropPanel.Width + 5;
                    currentSentenceWidth += dropPanel.Width + 5;
                    if (currentSentenceWidth > maxWidth)
                    {
                        isNewLine = true;
                    }
                }
            }
        }

        private void DragLabel_MouseDown(object sender, MouseEventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                _draggedLabel = label;
                label.DoDragDrop(label.Text, DragDropEffects.Copy);
            }
        }

        private void DropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void DropPanel_DragDrop(object sender, DragEventArgs e)
        {
            var panel = sender as Panel;
            if (panel != null && _draggedLabel != null)
            {
                panel.Controls.Clear();
                var label = new Label
                {
                    Text = _draggedLabel.Text,
                    AutoSize = true,
                    Location = new Point(5, 5),
                    Tag = _draggedLabel.Text
                };
                panel.Controls.Add(label);
                panel.Tag = _draggedLabel.Text;
                btnCheckAnswer.Enabled = true;
            }
        }

        private void LoadFillInTheBlanksExercise()
        {
            panelFillInTheBlanks.Visible = true;
            panelDragDrop.Visible = false;
            panelMultipleChoice.Visible = false;
            ClearFillInTheBlanksPanel();
            var questionLabel = new Label
            {
                Text = _currentExercise.Question ?? "Заповніть пропуски",
                Location = new Point(10, 40),
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                MaximumSize = new Size(panelFillInTheBlanks.Width - 20, 0)
            };
            panelFillInTheBlanks.Controls.Add(questionLabel);

            var correctAnswers = _currentExercise.CorrectAnswer.Split(',');
            int yPosition = questionLabel.Bottom + 20;

            for (int i = 0; i < correctAnswers.Length; i++)
            {
                var blankLabel = new Label
                {
                    Text = $"Пропуск {i + 1}:",
                    Location = new Point(10, yPosition),
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 10F)
                };
                panelFillInTheBlanks.Controls.Add(blankLabel);

                var textBox = new TextBox
                {
                    Location = new Point(blankLabel.Right + 10, yPosition),
                    Size = new Size(150, 25),
                    Font = new Font("Microsoft Sans Serif", 10F),
                    Tag = i
                };
                textBox.TextChanged += TextBox_TextChanged;
                panelFillInTheBlanks.Controls.Add(textBox);
                yPosition += 35;
            }
            var options = _currentExercise.GetOptionsList();
            if (options.Any())
            {
                var optionsLabel = new Label
                {
                    Text = "Доступні варіанти: " + string.Join(" ", options),
                    Location = new Point(10, yPosition + 10),
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic),
                    ForeColor = Color.Gray
                };
                panelFillInTheBlanks.Controls.Add(optionsLabel);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBoxes = panelFillInTheBlanks.Controls.OfType<TextBox>().ToList();
            btnCheckAnswer.Enabled = textBoxes.All(tb => !string.IsNullOrEmpty(tb.Text.Trim()));
        }

        private void ClearFillInTheBlanksPanel()
        {
            foreach (Control control in panelFillInTheBlanks.Controls.OfType<TextBox>().ToList())
            {
                panelFillInTheBlanks.Controls.Remove(control);
                control.Dispose();
            }
            foreach (Control control in panelFillInTheBlanks.Controls.OfType<Label>().ToList())
            {
                if (control != lblFillInTheBlanksTitle)
                {
                    panelFillInTheBlanks.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }

        private void LoadMultipleChoiceExercise()
        {
            panelFillInTheBlanks.Visible = false;
            panelDragDrop.Visible = false;
            panelMultipleChoice.Visible = true;
            lblQuestion.Text = _currentExercise.Question ?? "Питання відсутнє";
            var options = _currentExercise.GetOptionsList();
            for (int i = 0; i < options.Count && i < 4; i++)
            {
                var radioButton = panelMultipleChoice.Controls.Find($"radioOption{i + 1}", false).FirstOrDefault() as RadioButton;
                if (radioButton != null && i < options.Count)
                {
                    radioButton.Text = options[i] ?? "Варіант відповіді";
                    radioButton.Checked = false;
                    radioButton.Visible = true;
                }
            }
            for (int i = options.Count; i < 4; i++)
            {
                var radioButton = panelMultipleChoice.Controls.Find($"radioOption{i + 1}", false).FirstOrDefault() as RadioButton;
                if (radioButton != null)
                {
                    radioButton.Visible = false;
                }
            }
        }

        private void ClearExerciseElements()
        {
            foreach (Control control in panelFillInTheBlanks.Controls.OfType<TextBox>().ToList())
            {
                panelFillInTheBlanks.Controls.Remove(control);
                control.Dispose();
            }
            foreach (Control control in panelFillInTheBlanks.Controls.OfType<Label>().ToList())
            {
                if (control != lblFillInTheBlanksTitle)
                {
                    panelFillInTheBlanks.Controls.Remove(control);
                    control.Dispose();
                }
            }

            foreach (Control control in panelDragDrop.Controls.OfType<Panel>().ToList())
            {
                if (control != panelDragLabels)
                {
                    panelDragDrop.Controls.Remove(control);
                    control.Dispose();
                }
            }

            foreach (Control control in panelDragDrop.Controls.OfType<Label>().ToList())
            {
                if (control != lblDragDropTitle)
                {
                    panelDragDrop.Controls.Remove(control);
                    control.Dispose();
                }
            }

            panelDragLabels.Controls.Clear();
            _dragLabels.Clear();
            _dropPanels.Clear();
        }

        private void CheckFillInTheBlanksAnswer()
        {
            var textBoxes = panelFillInTheBlanks.Controls.OfType<TextBox>().ToList();

            var sortedTextBoxes = textBoxes.OrderBy(tb => (int)(tb.Tag ?? 0)).ToList();
            var userAnswers = sortedTextBoxes.Select(tb => tb.Text.Trim()).ToArray();
            var correctAnswers = _currentExercise.CorrectAnswer.Split(',');

            bool isCorrect = true;
            List<string> incorrectAnswers = new List<string>();

            for (int i = 0; i < Math.Min(userAnswers.Length, correctAnswers.Length); i++)
            {
                if (!string.Equals(userAnswers[i], correctAnswers[i].Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    isCorrect = false;
                    incorrectAnswers.Add($"Пропуск {i + 1}: ви ввели '{userAnswers[i]}', а правильно '{correctAnswers[i].Trim()}'");
                    sortedTextBoxes[i].BackColor = Color.LightCoral;
                }
                else
                {
                    sortedTextBoxes[i].BackColor = ColorTranslator.FromHtml("#93BFA6");
                }
            }

            if (isCorrect)
            {
                SaveProgress(_currentExercise.Id, ExerciseType.Grammar, true);
                ShowResult(isCorrect, string.Join(", ", userAnswers));
            }
            else
            {
                ShowResult(isCorrect, string.Join(", ", userAnswers), incorrectAnswers);
            }
        }

        private void CheckDragAndDropAnswer()
        {
            var userAnswers = _dropPanels.Select(p => p.Tag?.ToString() ?? "").ToArray();
            var correctAnswers = _currentExercise.CorrectAnswer.Split(',');
            bool isCorrect = true;
            List<string> incorrectAnswers = new List<string>();
            for (int i = 0; i < Math.Min(userAnswers.Length, correctAnswers.Length); i++)
            {
                var dropPanel = _dropPanels[i];
                var userAnswer = userAnswers[i];
                var correctAnswer = correctAnswers[i].Trim();

                if (!string.Equals(userAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    isCorrect = false;
                    incorrectAnswers.Add($"Пропуск {i + 1}: ви обрали '{userAnswer}', а правильно '{correctAnswer}'");
                    dropPanel.BackColor = Color.LightCoral; 
                }
                else
                {
                    dropPanel.BackColor = ColorTranslator.FromHtml("#93BFA6"); 
                }
            }

            if (isCorrect)
            {
                SaveProgress(_currentExercise.Id, ExerciseType.Grammar, true);
                ShowResult(isCorrect, string.Join(", ", userAnswers));
            }
            else
            {
                ShowResult(isCorrect, string.Join(", ", userAnswers), incorrectAnswers);
            }
        }

        private void CheckMultipleChoiceAnswer()
        {
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
                SaveProgress(_currentExercise.Id, ExerciseType.Grammar, true);
                ShowResult(isCorrect, selectedOption);
            }
            else
            {
                ShowResult(isCorrect, selectedOption);
            }
        }

        private void ShowResult(bool isCorrect, string userAnswer, List<string> incorrectAnswers = null)
        {
            string message;
            MessageBoxIcon icon;

            if (isCorrect)
            {
                message = $"Правильно!\n\nВаша відповідь: {userAnswer}\n\n{_currentExercise.Explanation}";
                icon = MessageBoxIcon.Information;

                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, icon);
                _currentExerciseIndex++;
                LoadNextExercise();
            }
            else
            {
                var incorrectDetails = incorrectAnswers != null ? string.Join("\n", incorrectAnswers) : "";
                message = $"Неправильно. Спробуйте ще раз!\n\n" +
                         $"Ваша відповідь: {userAnswer}\n" +
                         $"Правильна відповідь: {_currentExercise.CorrectAnswer}\n\n" +
                         $"{incorrectDetails}\n\n" +
                         $"{_currentExercise.Explanation}";
                icon = MessageBoxIcon.Warning;

                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, icon);
                if (panelMultipleChoice.Visible)
                {
                    ResetRadioButtons();
                    btnCheckAnswer.Enabled = false;
                }
                else if (panelFillInTheBlanks.Visible)
                {
                    btnCheckAnswer.Enabled = true;
                }
                else if (panelDragDrop.Visible)
                {
                    btnCheckAnswer.Enabled = true;
                }
            }
        }

        private void ResetRadioButtons()
        {
            foreach (Control control in panelMultipleChoice.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private string GetSelectedOption()
        {
            foreach (Control control in panelMultipleChoice.Controls)
            {
                if (control is RadioButton radio && radio.Checked && radio.Visible)
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

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            if (_currentExercise == null) return;

            if (panelFillInTheBlanks.Visible)
            {
                CheckFillInTheBlanksAnswer();
            }
            else if (panelDragDrop.Visible)
            {
                CheckDragAndDropAnswer();
            }
            else if (panelMultipleChoice.Visible)
            {
                CheckMultipleChoiceAnswer();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Ця кнопка більше не потрібна, але залишаємо для сумісності
            _currentExerciseIndex++;
            LoadNextExercise();
        }

        private void radioOption_CheckedChanged(object sender, EventArgs e)
        {
            if (panelMultipleChoice.Visible)
            {
                btnCheckAnswer.Enabled = true;
            }
        }

        private void panelDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panelDragDrop_DragDrop(object sender, DragEventArgs e)
        {
        }
    }
}