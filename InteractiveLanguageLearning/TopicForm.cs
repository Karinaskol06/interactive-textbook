using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class TopicForm : Form
    {
        private Language _selectedLanguage;
        private User _currentUser;
        private LanguageService _languageService;
        private ExerciseService _exerciseService;

        public TopicForm(Language language, User user)
        {
            InitializeComponent();
            _selectedLanguage = language;
            _currentUser = user;
            _languageService = new LanguageService();
            _exerciseService = new ExerciseService(); 
            LoadSectionsAndTopics();
            StyleControls();
        }

        private class TopicButtonTag
        {
            public Topic Topic { get; set; }
            public Section Section { get; set; }
        }

        private void LoadSectionsAndTopics()
        {
            try
            {
                var languageWithData = _languageService.GetLanguageWithSectionsAndTopics(_selectedLanguage.Id);

                if (languageWithData?.Sections == null || !languageWithData.Sections.Any())
                {
                    ShowNoDataMessage();
                    return;
                }
                lblLanguageName.Text = $"{languageWithData.Name}";
                PopulateSections(languageWithData.Sections);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateSections(System.Collections.Generic.List<Section> sections)
        {
            panelSections.Controls.Clear();

            int yPosition = 10;

            foreach (var section in sections)
            {
                var sectionPanel = CreateSectionPanel(section, yPosition);
                panelSections.Controls.Add(sectionPanel);

                yPosition += sectionPanel.Height + 10;
            }
        }

        private Panel CreateSectionPanel(Section section, int yPosition)
        {
            var panel = new Panel
            {
                Location = new Point(10, yPosition),
                Size = new Size(panelSections.Width - 25, 60),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(255, 235, 194),
                Tag = section
            };

            var lblSectionName = new Label
            {
                Text = section.Name,
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Sitka Text", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 31, 41)
            };
            panel.Controls.Add(lblSectionName);

            var lblDescription = new Label
            {
                Text = section.Description ?? "Опис відсутній",
                Location = new Point(10, 35),
                AutoSize = true,
                Font = new Font("Sitka Text", 10),
                ForeColor = Color.FromArgb(22, 31, 41)
            };
            panel.Controls.Add(lblDescription);

            panel.Click += (s, e) => ToggleTopics(section, panel);
            lblSectionName.Click += (s, e) => ToggleTopics(section, panel);
            lblDescription.Click += (s, e) => ToggleTopics(section, panel);

            return panel;
        }

        private void ToggleTopics(Section section, Panel sectionPanel)
        {
            var existingTopicsPanel = panelSections.Controls
                .OfType<Panel>()
                .FirstOrDefault(p => p.Tag?.ToString() == $"topics_{section.Id}");

            if (existingTopicsPanel != null)
            {
                panelSections.Controls.Remove(existingTopicsPanel);
                ReorganizePanels();
                return;
            }
            HideAllTopicPanels();
            var topicsPanel = CreateTopicsPanel(section, sectionPanel.Bottom + 5);
            panelSections.Controls.Add(topicsPanel);
            ReorganizePanels();
        }

        private void HideAllTopicPanels()
        {
            var topicPanels = panelSections.Controls
                .OfType<Panel>()
                .Where(p => p.Tag?.ToString()?.StartsWith("topics_") == true)
                .ToList();
            foreach (var panel in topicPanels)
            {
                panelSections.Controls.Remove(panel);
            }
        }

        private Panel CreateTopicsPanel(Section section, int yPosition)
        {
            var panel = new Panel
            {
                Location = new Point(20, yPosition),
                Size = new Size(panelSections.Width - 35, 40 + (section.Topics.Count * 45)),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 221, 165),
                Tag = $"topics_{section.Id}"
            };

            var lblTopicsTitle = new Label
            {
                Text = "Теми:",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Sitka Text", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 31, 41)
            };
            panel.Controls.Add(lblTopicsTitle);

            int topicY = 40;
            foreach (var topic in section.Topics)
            {
                var topicButton = CreateTopicButton(topic, section, topicY);
                panel.Controls.Add(topicButton);
                topicY += 45;
            }

            return panel;
        }

        private Button CreateTopicButton(Topic topic, Section section, int yPosition)
        {
            bool hasExercises = CheckIfTopicHasExercises(section.Name, topic.Id);

            var button = new Button
            {
                Text = $"{topic.Title}\n└ {topic.Description ?? "Без опису"}",
                Location = new Point(10, yPosition),
                Size = new Size(panelSections.Width - 65, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = hasExercises ? Color.FromArgb(104, 148, 146) : Color.LightGray,
                ForeColor = hasExercises ? Color.Black : Color.Gray,
                Font = new Font("Sitka Text", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Tag = new TopicButtonTag { Topic = topic, Section = section },
                Enabled = hasExercises 
            };

            button.FlatAppearance.BorderSize = 0;

            if (hasExercises)
            {
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 105, 102);
                button.FlatAppearance.MouseDownBackColor = Color.FromArgb(114, 181, 178);
            }

            button.Click += TopicButton_Click;

            return button;
        }

        private bool CheckIfTopicHasExercises(string sectionName, int topicId)
        {
            try
            {
                switch (sectionName)
                {
                    case "Граматика":
                        return _exerciseService.HasGrammarExercises(topicId);
                    case "Читання":
                        return _exerciseService.HasReadingExercises(topicId);
                    case "Словниковий запас":
                        return _exerciseService.HasVocabularyExercises(topicId);
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка перевірки вправ: {ex.Message}");
                return false;
            }
        }

        private void TopicButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag == null) return;

            try
            {
                var tagData = button.Tag as TopicButtonTag;
                if (tagData == null) return;

                var topic = tagData.Topic;
                var section = tagData.Section;
                if (!CheckIfTopicHasExercises(section.Name, topic.Id))
                {
                    MessageBox.Show($"Для теми '{topic.Title}' ще не додано вправ.\nСпробуйте пізніше або оберіть іншу тему.",
                                  "Вправи відсутні",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                OpenExerciseForm(section.Name, topic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося відкрити вправи: {ex.Message}",
                              "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExerciseForm(string sectionName, Topic topic)
        {
            try
            {
                Form exerciseForm = null;

                switch (sectionName)
                {
                    case "Граматика":
                        exerciseForm = new GrammarForm(_selectedLanguage, _currentUser, topic.Id);
                        break;
                    case "Читання":
                        exerciseForm = new ReadingForm(_selectedLanguage, _currentUser, topic.Id);
                        break;
                    case "Словниковий запас":
                        exerciseForm = new VocabularyForm(_selectedLanguage, _currentUser, topic.Id);
                        break;
                    default:
                        MessageBox.Show("Форма для цієї секції ще не реалізована", "Інформація",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }

                if (exerciseForm != null)
                {
                    this.Hide();
                    exerciseForm.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка відкриття вправ: {ex.Message}\nМожливо, вправи ще не додані до цієї теми.",
                              "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReorganizePanels()
        {
            try
            {
                var panels = panelSections.Controls
                    .OfType<Panel>()
                    .OrderBy(p => p.Location.Y)
                    .ToList();

                int yPosition = 10;
                foreach (var panel in panels)
                {
                    panel.Location = new Point(panel.Location.X, yPosition);

                    if (panel.Tag?.ToString()?.StartsWith("topics_") == true)
                    {
                        var sectionId = int.Parse(panel.Tag.ToString().Replace("topics_", ""));
                        var parentSectionPanel = panels
                            .FirstOrDefault(p => (p.Tag as Section)?.Id == sectionId);

                        if (parentSectionPanel != null)
                        {
                            yPosition = parentSectionPanel.Bottom + 5;
                            panel.Location = new Point(panel.Location.X, yPosition);
                        }
                    }

                    yPosition += panel.Height + 10;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка реорганізації панелей: {ex.Message}");
            }
        }

        private void ShowNoDataMessage()
        {
            var lblNoData = new Label
            {
                Text = "Для обраної мови не знайдено секцій та тем",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            panelSections.Controls.Add(lblNoData);
        }

        private void StyleControls()
        {
            this.BackColor = Color.Black;
            panelSections.BackColor = Color.Transparent;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}