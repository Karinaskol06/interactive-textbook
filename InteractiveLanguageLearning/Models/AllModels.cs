using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteractiveLanguageLearning.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();
    }

    public class Section
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }

        public List<Topic> Topics { get; set; } = new List<Topic>();
    }

    public class Topic
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderIndex { get; set; }
        public Section Section { get; set; }

        public List<VocabularyExercise> VocabularyExercises { get; set; } = new List<VocabularyExercise>();
        public List<ReadingExercise> ReadingExercises { get; set; } = new List<ReadingExercise>();
        public List<GrammarExercise> GrammarExercises { get; set; } = new List<GrammarExercise>();
    }

    public class TopicButtonTag
    {
        public Topic Topic { get; set; }
        public Section Section { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? CurrentLanguageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; } = 1;
        public Language CurrentLanguage { get; set; }
        public UserRole Role { get; set; }

        public List<UserProgress> Progress { get; set; } = new List<UserProgress>();
        public bool IsTeacher => Role?.Name == "teacher";
    }

    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }

    public interface IExercise
    {
        int Id { get; set; }
        int TopicId { get; set; }
        string Question { get; set; }
        string CorrectAnswer { get; set; }
        string Options { get; set; }
        Topic Topic { get; set; }
        List<string> GetOptionsList();
    }

    public class ExerciseEditModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string Explanation { get; set; }
        public ExerciseType ExerciseType { get; set; }

        // Додаткові поля для різних типів вправ
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string Example { get; set; }
        public string ImagePath { get; set; }
    }

    public class VocabularyExercise : IExercise
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Options { get; set; }
        public string Explanation { get; set; }
        public string? ImagePath { get; set; }
        public Topic Topic { get; set; }

        public List<string> GetOptionsList()
        {
            return new List<string>(Options.Split(','));
        }
    }

    public class ReadingExercise : IExercise
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Options { get; set; }
        public string Explanation { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public Topic Topic { get; set; }

        public List<string> GetOptionsList()
        {
            return new List<string>(Options.Split(','));
        }
    }

    public class GrammarExercise : IExercise
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Options { get; set; }
        public string Explanation { get; set; }
        public string Title { get; set; }
        public string Example { get; set; }
        public Topic Topic { get; set; }

        public List<string> GetOptionsList()
        {
            return Options?.Split(',')?.Select(opt => opt.Trim().Replace(" ", ", ")).ToList() ?? new List<string>();
        }
    }

    public class UserProgress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public bool Completed { get; set; }
        public int Score { get; set; }
        public int Attempts { get; set; }
        public DateTime LastAttempt { get; set; }
        public User User { get; set; }
    }

    public enum ExerciseType
    {
        Vocabulary,
        Reading,
        Grammar
    }

    // Моделі для відображення даних в UI
    public class UserStats
    {
        public int TotalExercises { get; set; }
        public int CompletedExercises { get; set; }
        public int TotalScore { get; set; }
        public double ProgressPercentage => TotalExercises > 0 ? (double)CompletedExercises / TotalExercises * 100 : 0;
    }

    public class ExerciseResult
    {
        public bool IsCorrect { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }
        public int ScoreEarned { get; set; }
    }

    public class LanguageProgress
    {
        public Language Language { get; set; }
        public int TotalExercises { get; set; }
        public int CompletedExercises { get; set; }
        public double ProgressPercentage => TotalExercises > 0 ? (double)CompletedExercises / TotalExercises * 100 : 0;
    }
}