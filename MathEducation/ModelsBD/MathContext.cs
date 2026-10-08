using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MathEducation.ModelsBD;

public partial class MathContext : DbContext
{
    public MathContext()
    {
    }

    public MathContext(DbContextOptions<MathContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnswerOption> AnswerOptions { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<LearningProgress> LearningProgresses { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=Math; Trusted_Connection=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnswerOption>(entity =>
        {
            entity.Property(e => e.AnswerOptionId)
                .ValueGeneratedNever()
                .HasColumnName("AnswerOptionID");
            entity.Property(e => e.Answer).HasMaxLength(100);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Task).WithMany(p => p.AnswerOptions)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnswerOptions_Tasks");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.Property(e => e.ErrorId)
                .ValueGeneratedNever()
                .HasColumnName("ErrorID");
            entity.Property(e => e.Error1)
                .HasMaxLength(50)
                .HasColumnName("Error");
            entity.Property(e => e.ErrorText).HasMaxLength(130);
            entity.Property(e => e.Hint).HasMaxLength(120);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Task).WithMany(p => p.Errors)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Errors_Tasks");
        });

        modelBuilder.Entity<LearningProgress>(entity =>
        {
            entity.HasKey(e => e.ProgressId);

            entity.ToTable("LearningProgress");

            entity.Property(e => e.ProgressId).HasColumnName("ProgressID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Task).WithMany(p => p.LearningProgresses)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LearningProgress_Tasks");

            entity.HasOne(d => d.User).WithMany(p => p.LearningProgresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LearningProgress_Users");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.SectionId)
                .ValueGeneratedNever()
                .HasColumnName("SectionID");
            entity.Property(e => e.Title).HasMaxLength(60);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.CorrectAnswer).HasMaxLength(30);
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.QuestionText).HasMaxLength(130);
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Topics");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.Property(e => e.TopicId)
                .ValueGeneratedNever()
                .HasColumnName("TopicID");
            entity.Property(e => e.DocName).HasMaxLength(50);
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Section).WithMany(p => p.Topics)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Topics_Sections");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Login).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
