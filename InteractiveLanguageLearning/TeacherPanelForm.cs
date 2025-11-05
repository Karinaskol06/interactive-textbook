using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class TeacherPanelForm : Form
    {
        private User _currentUser;
        private TeacherService _teacherService;
        private LanguageService _languageService;

        public TeacherPanelForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _teacherService = new TeacherService();
            _languageService = new LanguageService();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Завантажуємо всі теми з вправами
                var topics = _teacherService.GetAllTopicsWithExercises();
                treeViewExercises.Nodes.Clear();

                foreach (var topic in topics)
                {
                    var languageNode = treeViewExercises.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Text == topic.Section.Language.Name);

                    if (languageNode == null)
                    {
                        languageNode = new TreeNode(topic.Section.Language.Name);
                        treeViewExercises.Nodes.Add(languageNode);
                    }

                    var sectionNode = languageNode.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Text == topic.Section.Name);

                    if (sectionNode == null)
                    {
                        sectionNode = new TreeNode(topic.Section.Name);
                        languageNode.Nodes.Add(sectionNode);
                    }

                    var topicNode = new TreeNode($"{topic.Title} (ID: {topic.Id})")
                    {
                        Tag = topic
                    };

                    // Додаємо вправи як дочірні вузли
                    foreach (var exercise in topic.VocabularyExercises)
                    {
                        var exerciseNode = new TreeNode($"📝 {exercise.Question?.Substring(0, Math.Min(30, exercise.Question.Length))}...")
                        {
                            Tag = new ExerciseTag { Exercise = exercise, Type = ExerciseType.Vocabulary }
                        };
                        topicNode.Nodes.Add(exerciseNode);
                    }

                    foreach (var exercise in topic.ReadingExercises)
                    {
                        var exerciseNode = new TreeNode($"📖 {exercise.Title}")
                        {
                            Tag = new ExerciseTag { Exercise = exercise, Type = ExerciseType.Reading }
                        };
                        topicNode.Nodes.Add(exerciseNode);
                    }

                    foreach (var exercise in topic.GrammarExercises)
                    {
                        var exerciseNode = new TreeNode($"🔤 {exercise.Title}")
                        {
                            Tag = new ExerciseTag { Exercise = exercise, Type = ExerciseType.Grammar }
                        };
                        topicNode.Nodes.Add(exerciseNode);
                    }

                    sectionNode.Nodes.Add(topicNode);
                }

                treeViewExercises.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddExercise_Click(object sender, EventArgs e)
        {
            var addForm = new ExerciseEditForm(null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEditExercise_Click(object sender, EventArgs e)
        {
            if (treeViewExercises.SelectedNode?.Tag is ExerciseTag exerciseTag)
            {
                var exercise = exerciseTag.Exercise;
                // Тепер передаємо тільки вправу, тип визначиться автоматично
                var editForm = new ExerciseEditForm(exercise);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть вправу для редагування", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteExercise_Click(object sender, EventArgs e)
        {
            if (treeViewExercises.SelectedNode?.Tag is ExerciseTag exerciseTag)
            {
                var exercise = exerciseTag.Exercise;
                var exerciseType = exerciseTag.Type;

                var result = MessageBox.Show("Ви впевнені, що хочете видалити цю вправу?",
                                           "Підтвердження видалення",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _teacherService.DeleteExercise(exerciseType, exercise.Id);
                    LoadData();
                    MessageBox.Show("Вправу видалено успішно", "Успіх",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть вправу для видалення", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ExerciseTag
    {
        public IExercise Exercise { get; set; }
        public ExerciseType Type { get; set; }
    }
}