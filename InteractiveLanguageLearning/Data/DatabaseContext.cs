using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using InteractiveLanguageLearning.Models;
using System.Configuration;

namespace InteractiveLanguageLearning.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VocabularyExercise> VocabularyExercises { get; set; }
        public DbSet<ReadingExercise> ReadingExercises { get; set; }
        public DbSet<GrammarExercise> GrammarExercises { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;port=3305;database=interactive_language_learning;user=root;password=11111;charset=utf8mb4;";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфігурація для Language
            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Languages");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(50);
                entity.Property(e => e.Code).HasColumnName("code").HasMaxLength(5);
            });

            // Конфігурація для Section
            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Sections");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.LanguageId).HasColumnName("language_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(50);
                entity.Property(e => e.Description).HasColumnName("description");

                entity.HasOne(s => s.Language)
                      .WithMany(l => l.Sections)
                      .HasForeignKey(s => s.LanguageId);
            });

            // Конфігурація для Topic
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topics");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SectionId).HasColumnName("section_id");
                entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(100);
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.OrderIndex).HasColumnName("order_index");

                entity.HasOne(t => t.Section)
                      .WithMany(s => s.Topics)
                      .HasForeignKey(t => t.SectionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Username).HasColumnName("username").HasMaxLength(50);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(100);
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(255);
                entity.Property(e => e.CurrentLanguageId).HasColumnName("current_language_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.RoleId).HasColumnName("role_id").HasDefaultValue(1);

                entity.Property(e => e.RoleId)
                      .HasColumnName("role_id")
                      .HasDefaultValue(1)
                      .IsRequired(true); 

                entity.HasOne(u => u.CurrentLanguage)
                      .WithMany()
                      .HasForeignKey(u => u.CurrentLanguageId);

                entity.HasOne(u => u.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.RoleId);
            });

            // Конфігурація для VocabularyExercise
            modelBuilder.Entity<VocabularyExercise>(entity =>
            {
                entity.ToTable("VocabularyExercises");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TopicId).HasColumnName("topic_id");
                entity.Property(e => e.Question).HasColumnName("question");
                entity.Property(e => e.CorrectAnswer).HasColumnName("correct_answer").HasMaxLength(255);
                entity.Property(e => e.Options).HasColumnName("options");
                entity.Property(e => e.Explanation).HasColumnName("explanation");
                entity.Property(e => e.ImagePath).HasColumnName("image_path").HasMaxLength(255); 
                entity.HasOne(v => v.Topic)
                      .WithMany(t => t.VocabularyExercises)
                      .HasForeignKey(v => v.TopicId);
            });

            // Конфігурація для ReadingExercise
            modelBuilder.Entity<ReadingExercise>(entity =>
            {
                entity.ToTable("ReadingExercises");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TopicId).HasColumnName("topic_id");
                entity.Property(e => e.Question).HasColumnName("question");
                entity.Property(e => e.CorrectAnswer).HasColumnName("correct_answer").HasMaxLength(255);
                entity.Property(e => e.Options).HasColumnName("options");
                entity.Property(e => e.Explanation).HasColumnName("explanation");
                entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(200);
                entity.Property(e => e.TextContent).HasColumnName("text_content");

                entity.HasOne(r => r.Topic)
                      .WithMany(t => t.ReadingExercises)
                      .HasForeignKey(r => r.TopicId);
            });

            // Конфігурація для GrammarExercise
            modelBuilder.Entity<GrammarExercise>(entity =>
            {
                entity.ToTable("GrammarExercises");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TopicId).HasColumnName("topic_id");
                entity.Property(e => e.Question).HasColumnName("question");
                entity.Property(e => e.CorrectAnswer).HasColumnName("correct_answer").HasMaxLength(255);
                entity.Property(e => e.Options).HasColumnName("options");
                entity.Property(e => e.Explanation).HasColumnName("explanation");
                entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(200);
                entity.Property(e => e.Example).HasColumnName("example");

                entity.HasOne(g => g.Topic)
                      .WithMany(t => t.GrammarExercises)
                      .HasForeignKey(g => g.TopicId);
            });

            // Конфігурація для UserProgress
            modelBuilder.Entity<UserProgress>(entity =>
            {
                entity.ToTable("UserProgress");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

                entity.Property(e => e.ExerciseType)
                      .HasColumnName("exercise_type")
                      .HasConversion<string>() 
                      .HasMaxLength(20); 

                entity.Property(e => e.Completed).HasColumnName("completed");
                entity.Property(e => e.Score).HasColumnName("score");
                entity.Property(e => e.Attempts).HasColumnName("attempts");
                entity.Property(e => e.LastAttempt).HasColumnName("last_attempt");

                entity.HasOne(up => up.User)
                      .WithMany(u => u.Progress)
                      .HasForeignKey(up => up.UserId);

                entity.HasIndex(p => new { p.UserId, p.ExerciseType });
                entity.HasIndex(p => p.LastAttempt);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}