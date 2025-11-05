using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class ExerciseEditForm : Form
    {
        private IExercise _exercise;
        private ExerciseType _exerciseType;
        private TeacherService _teacherService;
        private LanguageService _languageService;

        public ExerciseEditForm(IExercise exercise = null)
        {
            InitializeComponent();
            _exercise = exercise;
            _teacherService = new TeacherService();
            _languageService = new LanguageService();

            InitializeForm();
        }

        private void InitializeForm()
        {
            var languages = _languageService.GetAllLanguages();
            cmbLanguage.DataSource = languages;
            cmbLanguage.DisplayMember = "Name";
            cmbLanguage.ValueMember = "Id";

            if (_exercise != null)
            {
                LoadExerciseData();
                DetermineExerciseTypeFromExisting();
            }
            else
            {
                this.Text = "Створення нової вправи";
                SetupFormBasedOnSection();
            }
        }

        private void SetupFormBasedOnSection()
        {
            _exerciseType = ExerciseType.Vocabulary;
            SetupFormBasedOnExerciseType();

            if (cmbSection.SelectedItem is Section selectedSection)
            {
                DetermineExerciseTypeFromSection();
            }
        }

        private void DetermineExerciseTypeFromExisting()
        {
            if (_exercise is VocabularyExercise)
            {
                _exerciseType = ExerciseType.Vocabulary;
                this.Text = "Редагування вправи зі словникового запасу";
            }
            else if (_exercise is ReadingExercise)
            {
                _exerciseType = ExerciseType.Reading;
                this.Text = "Редагування вправи з читання";
            }
            else if (_exercise is GrammarExercise)
            {
                _exerciseType = ExerciseType.Grammar;
                this.Text = "Редагування вправи з граматики";
            }

            SetupFormBasedOnExerciseType();
        }

        private void DetermineExerciseTypeFromSection()
        {
            if (cmbSection.SelectedItem is Section selectedSection)
            {
                switch (selectedSection.Name)
                {
                    case "Словниковий запас":
                        _exerciseType = ExerciseType.Vocabulary;
                        this.Text = "Створення вправи зі словникового запасу";
                        break;
                    case "Читання":
                        _exerciseType = ExerciseType.Reading;
                        this.Text = "Створення вправи з читання";
                        break;
                    case "Граматика":
                        _exerciseType = ExerciseType.Grammar;
                        this.Text = "Створення вправи з граматики";
                        break;
                    default:
                        _exerciseType = ExerciseType.Vocabulary;
                        break;
                }

                SetupFormBasedOnExerciseType();
            }
        }

        private void SetupFormBasedOnExerciseType()
        {
            switch (_exerciseType)
            {
                case ExerciseType.Vocabulary:
                    SetupVocabularyForm();
                    break;
                case ExerciseType.Reading:
                    SetupReadingForm();
                    break;
                case ExerciseType.Grammar:
                    SetupGrammarForm();
                    break;
            }
        }

        private void SetupVocabularyForm()
        {
            lblTitle.Text = "Необов'язкове \nполе";
            lblTextContent.Text = "Необов'язкове \nполе";
            lblExample.Text = "Необов'язкове \nполе";
            txtTextContent.Text = "";
            txtExample.Text = "";
        }

        private void SetupReadingForm()
        {
            lblTitle.Text = "Назва тексту";
            lblTextContent.Text = "Текст для читання";
            lblExample.Text = "Необов'язкове \nполе";
        }

        private void SetupGrammarForm()
        {
            lblTitle.Text = "Назва теми";
            lblTextContent.Text = "Необов'язкове \nполе";
            lblExample.Text = "Приклад";
        }

        private void LoadExerciseData()
        {
            txtQuestion.Text = _exercise.Question;
            txtCorrectAnswer.Text = _exercise.CorrectAnswer;

            var optionsList = _exercise.GetOptionsList();
            txtOptions.Text = string.Join(",", optionsList);

            txtExplanation.Text = (_exercise as dynamic)?.Explanation ?? "";

            if (_exercise is VocabularyExercise vocab)
            {
                txtTitle.Text = "";
                txtTextContent.Text = "";
                txtExample.Text = "";
            }
            else if (_exercise is ReadingExercise reading)
            {
                txtTitle.Text = reading.Title;
                txtTextContent.Text = reading.TextContent;
                txtExample.Text = "";
            }
            else if (_exercise is GrammarExercise grammar)
            {
                txtTitle.Text = grammar.Title;
                txtTextContent.Text = grammar.Explanation;
                txtExample.Text = grammar.Example;
            }

            var topic = (_exercise as dynamic)?.Topic;
            if (topic != null)
            {
                cmbLanguage.SelectedValue = topic.Section.LanguageId;
                cmbLanguage_SelectedIndexChanged(null, null);
                cmbSection.SelectedValue = topic.SectionId;
                cmbSection_SelectedIndexChanged(null, null);
                cmbTopic.SelectedValue = topic.Id;
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem is Language selectedLanguage)
            {
                cmbSection.DataSource = selectedLanguage.Sections;
                cmbSection.DisplayMember = "Name";
                cmbSection.ValueMember = "Id";
                if (_exercise == null)
                {
                    SetupFormBasedOnSection();
                }
            }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedItem is Section selectedSection)
            {
                cmbTopic.DataSource = selectedSection.Topics.OrderBy(t => t.OrderIndex).ToList();
                cmbTopic.DisplayMember = "Title";
                cmbTopic.ValueMember = "Id";

                if (_exercise == null)
                {
                    DetermineExerciseTypeFromSection();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var topicId = (int)cmbTopic.SelectedValue;
                var options = txtOptions.Text.Split(',').Select(o => o.Trim()).ToList();
                switch (_exerciseType)
                {
                    case ExerciseType.Vocabulary:
                        Console.WriteLine("Saving as VOCABULARY exercise");
                        SaveVocabularyExercise(topicId, options);
                        break;
                    case ExerciseType.Reading:
                        Console.WriteLine("Saving as READING exercise");
                        SaveReadingExercise(topicId, options);
                        break;
                    case ExerciseType.Grammar:
                        Console.WriteLine("Saving as GRAMMAR exercise");
                        SaveGrammarExercise(topicId, options);
                        break;
                }

                MessageBox.Show($"Вправу успішно збережено! Тип: {_exerciseType}", "Успіх",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveVocabularyExercise(int topicId, List<string> options)
        {
            var exercise = _exercise as VocabularyExercise ?? new VocabularyExercise();
            exercise.TopicId = topicId;
            exercise.Question = txtQuestion.Text;
            exercise.CorrectAnswer = txtCorrectAnswer.Text;

            exercise.Options = string.Join(",", options.Select(o => o.Trim()));

            exercise.Explanation = txtExplanation.Text;

            if (_exercise == null)
                _teacherService.AddVocabularyExercise(exercise);
            else
                _teacherService.UpdateVocabularyExercise(exercise);
        }

        private void SaveReadingExercise(int topicId, List<string> options)
        {
            var exercise = _exercise as ReadingExercise ?? new ReadingExercise();
            exercise.TopicId = topicId;
            exercise.Title = txtTitle.Text;
            exercise.TextContent = txtTextContent.Text;
            exercise.Question = txtQuestion.Text;
            exercise.CorrectAnswer = txtCorrectAnswer.Text;
            exercise.Options = string.Join(",", options);
            exercise.Explanation = txtExplanation.Text;

            if (_exercise == null)
                _teacherService.AddReadingExercise(exercise);
            else
                _teacherService.UpdateReadingExercise(exercise);
        }

        private void SaveGrammarExercise(int topicId, List<string> options)
        {
            var exercise = _exercise as GrammarExercise ?? new GrammarExercise();
            exercise.TopicId = topicId;
            exercise.Title = txtTitle.Text;
            exercise.Explanation = txtExplanation.Text;
            exercise.Question = txtQuestion.Text;
            exercise.CorrectAnswer = txtCorrectAnswer.Text;

            exercise.Options = string.Join(",", options.Select(o => o.Trim()));

            exercise.Example = txtExample.Text;

            if (_exercise == null)
                _teacherService.AddGrammarExercise(exercise);
            else
                _teacherService.UpdateGrammarExercise(exercise);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Будь ласка, введіть питання", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorrectAnswer.Text))
            {
                MessageBox.Show("Будь ласка, введіть правильну відповідь", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOptions.Text))
            {
                MessageBox.Show("Будь ласка, введіть варіанти відповідей", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_exerciseType == ExerciseType.Reading)
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Будь ласка, введіть назву тексту", "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtTextContent.Text))
                {
                    MessageBox.Show("Будь ласка, введіть текст для читання", "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_exerciseType == ExerciseType.Grammar)
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Будь ласка, введіть назву граматичної теми", "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}