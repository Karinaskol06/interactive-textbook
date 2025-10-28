using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return _context.Languages
                .Include(l => l.Sections)
                .ThenInclude(s => s.Topics)
                .FirstOrDefault(l => l.Id == id);
        }
    }

    public class ExerciseService
    {
        public ExerciseService()
        {
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
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            return user;
        }

        public User Register(string username, string email, string password)
        {
            using var context = new ApplicationDbContext();

            var defaultLanguage = context.Languages.FirstOrDefault();

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = password,
                CurrentLanguageId = defaultLanguage?.Id,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public UserStats GetUserStats(int userId)
        {
            using var context = new ApplicationDbContext();

            try
            {
                Console.WriteLine($"=== GetUserStats for UserId: {userId} ===");

                var totalExercises = context.VocabularyExercises.Count() +
                                   context.ReadingExercises.Count() +
                                   context.GrammarExercises.Count();

                var completedExercises = context.UserProgress
                    .Count(p => p.UserId == userId && p.Completed);

                var totalScore = context.UserProgress
                    .Where(p => p.UserId == userId)
                    .Sum(p => p.Score);

                Console.WriteLine($"Total exercises: {totalExercises}");
                Console.WriteLine($"Completed exercises: {completedExercises}");
                Console.WriteLine($"Total score: {totalScore}");

                var allProgress = context.UserProgress
                    .Where(p => p.UserId == userId)
                    .ToList();

                Console.WriteLine($"All progress records for user: {allProgress.Count}");
                foreach (var prog in allProgress)
                {
                    Console.WriteLine($"  ExerciseId: {prog.ExerciseId}, Type: {prog.ExerciseType}, Completed: {prog.Completed}, Score: {prog.Score}");
                }

                return new UserStats
                {
                    TotalExercises = totalExercises,
                    CompletedExercises = completedExercises,
                    TotalScore = totalScore
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserStats: {ex.Message}");
                return new UserStats(); 
            }
        }

        public int GetCompletedExercisesByLanguage(int userId, int languageId)
        {
            using var context = new ApplicationDbContext();

            return context.UserProgress
                .Count(p => p.UserId == userId && p.Completed);
        }
    }
}