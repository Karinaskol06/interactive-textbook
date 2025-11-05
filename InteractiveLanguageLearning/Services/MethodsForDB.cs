using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InteractiveLanguageLearning.Services
{
    public class LanguageService
    {
        private readonly ApplicationDbContext _context;

        public LanguageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public LanguageService()
        {
        }

        public List<Language> GetAllLanguages()
        {
            using var context = new ApplicationDbContext();
            return context.Languages
                .Include(l => l.Sections)
                .ThenInclude(s => s.Topics)
                .ToList();
        }

        public Language GetLanguageById(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Languages
                .Include(l => l.Sections)
                .ThenInclude(s => s.Topics)
                .FirstOrDefault(l => l.Id == id);
        }

        public Language GetLanguageWithSectionsAndTopics(int languageId)
        {
            using var context = new ApplicationDbContext();
            return context.Languages
                .Where(l => l.Id == languageId)
                .Include(l => l.Sections)
                .ThenInclude(s => s.Topics.OrderBy(t => t.OrderIndex))
                .FirstOrDefault();
        }
    }

    public class ExerciseService
    {
        public ExerciseService()
        {
        }

        public bool HasVocabularyExercises(int topicId)
        {
            using var context = new ApplicationDbContext();
            var count = context.VocabularyExercises.Count(ve => ve.TopicId == topicId);
            Debug.WriteLine($"Vocabulary exercises for topic {topicId}: {count}");
            return count > 0;
        }

        public bool HasReadingExercises(int topicId)
        {
            using var context = new ApplicationDbContext();
            return context.ReadingExercises.Any(re => re.TopicId == topicId);
        }

        public bool HasGrammarExercises(int topicId)
        {
            using var context = new ApplicationDbContext();
            return context.GrammarExercises.Any(ge => ge.TopicId == topicId);
        }

        public List<VocabularyExercise> GetVocabularyExercisesByTopic(int topicId)
        {
            using var context = new ApplicationDbContext();
            return context.VocabularyExercises
                .Where(e => e.TopicId == topicId)
                .ToList();
        }

        public List<ReadingExercise> GetReadingExercisesByTopic(int topicId)
        {
            using var context = new ApplicationDbContext();
            return context.ReadingExercises
                .Where(e => e.TopicId == topicId)
                .ToList();
        }

        public List<GrammarExercise> GetGrammarExercisesByTopic(int topicId)
        {
            using var context = new ApplicationDbContext();
            return context.GrammarExercises
                .Where(e => e.TopicId == topicId)
                .ToList();
        }

        public IExercise GetExerciseById(ExerciseType type, int exerciseId)
        {
            using var context = new ApplicationDbContext();
            return type switch
            {
                ExerciseType.Vocabulary => context.VocabularyExercises.Find(exerciseId),
                ExerciseType.Reading => context.ReadingExercises.Find(exerciseId),
                ExerciseType.Grammar => context.GrammarExercises.Find(exerciseId),
                _ => null
            };
        }
    }

    public class UserService
    {
        public UserService()
        {
        }

        public void UpdateUserProgress(int userId, int exerciseId, ExerciseType exerciseType, bool isCorrect, int score)
        {
            using var context = new ApplicationDbContext();

            try
            {
                Console.WriteLine($"=== UpdateUserProgress ===");
                Console.WriteLine($"UserId: {userId}, ExerciseId: {exerciseId}, ExerciseType: {exerciseType}");

                var progress = context.UserProgress
                    .FirstOrDefault(p => p.UserId == userId && p.ExerciseId == exerciseId && p.ExerciseType == exerciseType);

                Console.WriteLine($"Existing progress found: {progress != null}");

                if (progress == null)
                {
                    progress = new UserProgress
                    {
                        UserId = userId,
                        ExerciseId = exerciseId,
                        ExerciseType = exerciseType,
                        Attempts = 1,
                        Score = isCorrect ? score : 0,
                        Completed = isCorrect,
                        LastAttempt = DateTime.Now
                    };
                    Console.WriteLine("Creating NEW progress record");
                    context.UserProgress.Add(progress);
                }
                else
                {
                    progress.Attempts++;
                    if (isCorrect)
                    {
                        progress.Score = Math.Max(progress.Score, score);
                        progress.Completed = true;
                    }
                    progress.LastAttempt = DateTime.Now;
                    Console.WriteLine("UPDATING existing progress record");
                }
                var entry = context.Entry(progress);
                Console.WriteLine($"Entity State: {entry.State}");
                Console.WriteLine($"UserId: {progress.UserId}, ExerciseId: {progress.ExerciseId}, Completed: {progress.Completed}");

                var changes = context.SaveChanges();
                Console.WriteLine($"SaveChanges affected {changes} records");
                Console.WriteLine("=== UpdateUserProgress SUCCESS ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== UpdateUserProgress ERROR ===");
                Console.WriteLine($"Error: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Error: {ex.InnerException.Message}");

                    if (ex.InnerException is MySqlConnector.MySqlException mysqlEx)
                    {
                        Console.WriteLine($"MySQL Error Code: {mysqlEx.ErrorCode}");
                        Console.WriteLine($"MySQL Number: {mysqlEx.Number}");
                    }
                }

                MessageBox.Show($"Не вдалося зберегти прогрес: {ex.InnerException?.Message ?? ex.Message}",
                              "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public User Authenticate(string username, string password)
        {
            using var context = new ApplicationDbContext();

            var user = context.Users
                .Include(u => u.CurrentLanguage)
                .Include(u => u.Role) // Додаємо завантаження ролі
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            return user;
        }

        public User Register(string username, string email, string password, int roleId = 1)
        {
            using var context = new ApplicationDbContext();

            var defaultLanguage = context.Languages.FirstOrDefault();

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = password,
                CurrentLanguageId = defaultLanguage?.Id,
                RoleId = roleId,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(user);
            context.SaveChanges();

            return context.Users
        .Include(u => u.CurrentLanguage)
        .Include(u => u.Role)
        .FirstOrDefault(u => u.Id == user.Id);
        }

        public void UpdateUserRole(int userId, int roleId)
        {
            using var context = new ApplicationDbContext();
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.RoleId = roleId;
                context.SaveChanges();
            }
        }

        public List<UserRole> GetAllRoles()
        {
            using var context = new ApplicationDbContext();
            return context.UserRoles.ToList();
        }

        public UserStats GetUserStats(int userId)
        {
            using var context = new ApplicationDbContext();

            var totalExercises = context.VocabularyExercises.Count() +
                               context.ReadingExercises.Count() +
                               context.GrammarExercises.Count();

            var completedExercises = context.UserProgress
                .Count(up => up.UserId == userId && up.Completed);

            var totalScore = context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Sum(up => up.Score);

            return new UserStats
            {
                TotalExercises = totalExercises,
                CompletedExercises = completedExercises,
                TotalScore = totalScore
                // ProgressPercentage обчислюється автоматично - не потрібно присвоювати
            };
        }

        public UserStats GetUserStatsByLanguage(int userId, int languageId)
        {
            using var context = new ApplicationDbContext();

            // Отримуємо всі вправи для конкретної мови
            var totalExercises = context.VocabularyExercises
                .Count(ve => ve.Topic.Section.LanguageId == languageId) +
                context.ReadingExercises
                .Count(re => re.Topic.Section.LanguageId == languageId) +
                context.GrammarExercises
                .Count(ge => ge.Topic.Section.LanguageId == languageId);

            // Отримуємо виконані вправи для конкретної мови
            var completedExercises = context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Join(context.VocabularyExercises,
                    up => up.ExerciseId,
                    ve => ve.Id,
                    (up, ve) => new { up, ve })
                .Count(x => x.ve.Topic.Section.LanguageId == languageId) +

                context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Join(context.ReadingExercises,
                    up => up.ExerciseId,
                    re => re.Id,
                    (up, re) => new { up, re })
                .Count(x => x.re.Topic.Section.LanguageId == languageId) +

                context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Join(context.GrammarExercises,
                    up => up.ExerciseId,
                    ge => ge.Id,
                    (up, ge) => new { up, ge })
                .Count(x => x.ge.Topic.Section.LanguageId == languageId);

            // Отримуємо загальний бал для конкретної мови
            var totalScore = context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Join(context.VocabularyExercises,
                    up => up.ExerciseId,
                    ve => ve.Id,
                    (up, ve) => new { up, ve })
                .Where(x => x.ve.Topic.Section.LanguageId == languageId)
                .Sum(x => x.up.Score) +

                context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Join(context.ReadingExercises,
                    up => up.ExerciseId,
                    re => re.Id,
                    (up, re) => new { up, re })
                .Where(x => x.re.Topic.Section.LanguageId == languageId)
                .Sum(x => x.up.Score) +

                context.UserProgress
                .Where(up => up.UserId == userId && up.Completed)
                .Join(context.GrammarExercises,
                    up => up.ExerciseId,
                    ge => ge.Id,
                    (up, ge) => new { up, ge })
                .Where(x => x.ge.Topic.Section.LanguageId == languageId)
                .Sum(x => x.up.Score);

            return new UserStats
            {
                TotalExercises = totalExercises,
                CompletedExercises = completedExercises,
                TotalScore = totalScore
                // ProgressPercentage обчислюється автоматично - не потрібно присвоювати
            };
        }

        public Dictionary<Language, UserStats> GetAllLanguagesStats(int userId)
        {
            using var context = new ApplicationDbContext();
            var languages = context.Languages.ToList();
            var stats = new Dictionary<Language, UserStats>();

            foreach (var language in languages)
            {
                stats[language] = GetUserStatsByLanguage(userId, language.Id);
            }

            return stats;
        }
    }

    public class TeacherService
    {
        public List<Topic> GetAllTopicsWithExercises()
        {
            using var context = new ApplicationDbContext();
            return context.Topics
                .Include(t => t.Section)
                .ThenInclude(s => s.Language)
                .Include(t => t.VocabularyExercises)
                .Include(t => t.ReadingExercises)
                .Include(t => t.GrammarExercises)
                .OrderBy(t => t.Section.Language.Name)
                .ThenBy(t => t.Section.Name)
                .ThenBy(t => t.OrderIndex)
                .ToList();
        }

        /*public void AddVocabularyExercise(VocabularyExercise exercise)
        {
            using var context = new ApplicationDbContext();
            context.VocabularyExercises.Add(exercise);
            context.SaveChanges();
        }*/

        public void AddReadingExercise(ReadingExercise exercise)
        {
            using var context = new ApplicationDbContext();
            context.ReadingExercises.Add(exercise);
            context.SaveChanges();
        }

        public void AddGrammarExercise(GrammarExercise exercise)
        {
            using var context = new ApplicationDbContext();
            context.GrammarExercises.Add(exercise);
            context.SaveChanges();
        }

        public void AddVocabularyExercise(VocabularyExercise exercise)
        {
            using var context = new ApplicationDbContext();
            try
            {
                Debug.WriteLine($"=== AddVocabularyExercise ===");
                Debug.WriteLine($"TopicId: {exercise.TopicId}");
                Debug.WriteLine($"Question: {exercise.Question}");
                Debug.WriteLine($"CorrectAnswer: {exercise.CorrectAnswer}");
                Debug.WriteLine($"Options: {exercise.Options}");
                Debug.WriteLine($"Explanation: {exercise.Explanation}");

                context.VocabularyExercises.Add(exercise);
                var changes = context.SaveChanges();

                Debug.WriteLine($"SaveChanges affected {changes} records");
                Debug.WriteLine($"New exercise ID: {exercise.Id}");
                Debug.WriteLine("=== AddVocabularyExercise SUCCESS ===");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"=== AddVocabularyExercise ERROR ===");
                Debug.WriteLine($"Error: {ex.Message}");
                Debug.WriteLine($"Inner: {ex.InnerException?.Message}");
                throw;
            }
        }

        public void UpdateVocabularyExercise(VocabularyExercise exercise)
        {
            using var context = new ApplicationDbContext();
            var existing = context.VocabularyExercises.Find(exercise.Id);
            if (existing != null)
            {
                existing.Question = exercise.Question;
                existing.CorrectAnswer = exercise.CorrectAnswer;
                existing.Options = exercise.Options;
                existing.Explanation = exercise.Explanation;
                existing.ImagePath = exercise.ImagePath;
                context.SaveChanges();
            }
        }

        public void UpdateReadingExercise(ReadingExercise exercise)
        {
            using var context = new ApplicationDbContext();
            var existing = context.ReadingExercises.Find(exercise.Id);
            if (existing != null)
            {
                existing.Title = exercise.Title;
                existing.TextContent = exercise.TextContent;
                existing.Question = exercise.Question;
                existing.CorrectAnswer = exercise.CorrectAnswer;
                existing.Options = exercise.Options;
                existing.Explanation = exercise.Explanation;
                context.SaveChanges();
            }
        }

        public void UpdateGrammarExercise(GrammarExercise exercise)
        {
            using var context = new ApplicationDbContext();
            var existing = context.GrammarExercises.Find(exercise.Id);
            if (existing != null)
            {
                existing.Title = exercise.Title;
                existing.Explanation = exercise.Explanation;
                existing.Question = exercise.Question;
                existing.CorrectAnswer = exercise.CorrectAnswer;
                existing.Options = exercise.Options;
                existing.Example = exercise.Example;
                context.SaveChanges();
            }
        }

        public void DeleteExercise(ExerciseType type, int exerciseId)
        {
            using var context = new ApplicationDbContext();
            switch (type)
            {
                case ExerciseType.Vocabulary:
                    var vocab = context.VocabularyExercises.Find(exerciseId);
                    if (vocab != null)
                    {
                        context.VocabularyExercises.Remove(vocab);
                        context.SaveChanges();
                    }
                    break;
                case ExerciseType.Reading:
                    var reading = context.ReadingExercises.Find(exerciseId);
                    if (reading != null)
                    {
                        context.ReadingExercises.Remove(reading);
                        context.SaveChanges();
                    }
                    break;
                case ExerciseType.Grammar:
                    var grammar = context.GrammarExercises.Find(exerciseId);
                    if (grammar != null)
                    {
                        context.GrammarExercises.Remove(grammar);
                        context.SaveChanges();
                    }
                    break;
            }
        }

        public List<Language> GetAllLanguages()
        {
            using var context = new ApplicationDbContext();
            return context.Languages
                .Include(l => l.Sections)
                .ThenInclude(s => s.Topics)
                .ToList();
        }
    }
}