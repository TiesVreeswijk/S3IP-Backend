using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define unique constraints
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<Exercise>()
            .HasIndex(e => e.Name).IsUnique();

        // Define primary keys and auto-increment where necessary
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id); // Assuming `UserId` is the primary key

        modelBuilder.Entity<Exercise>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Training>()
            .HasKey(t => t.TrainingId);
        modelBuilder.Entity<Training>()
            .Property(t => t.TrainingId)
            .ValueGeneratedOnAdd(); // Auto-increment

        modelBuilder.Entity<TrainingSession>()
            .HasKey(ts => ts.TrainingSessionId);
        modelBuilder.Entity<TrainingSession>()
            .Property(ts => ts.TrainingSessionId)
            .ValueGeneratedOnAdd(); // Auto-increment

        modelBuilder.Entity<TrainingExercise>()
            .HasKey(te => te.TrainingExerciseId); // Assuming this is the primary key
        modelBuilder.Entity<TrainingExercise>()
            .Property(te => te.TrainingExerciseId)
            .ValueGeneratedOnAdd(); // Auto-increment

        modelBuilder.Entity<TrainingSessionExercise>()
            .HasKey(tse => tse.TrainingSessionExerciseId); // Assuming this is the primary key
        modelBuilder.Entity<TrainingSessionExercise>()
            .Property(tse => tse.TrainingSessionExerciseId)
            .ValueGeneratedOnAdd(); // Auto-increment

        // Define relationships
        modelBuilder.Entity<Training>()
            .HasMany(t => t.TrainingSessions)
            .WithOne(ts => ts.Training)
            .HasForeignKey(ts => ts.TrainingId);

        modelBuilder.Entity<TrainingSession>()
            .HasMany(ts => ts.TrainingSessionExercises)
            .WithOne(tse => tse.TrainingSession)
            .HasForeignKey(tse => tse.TrainingSessionId);

        modelBuilder.Entity<TrainingExercise>()
            .HasOne(te => te.Training)
            .WithMany(t => t.TrainingExercises)
            .HasForeignKey(te => te.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TrainingExercise>()
            .HasOne(te => te.Exercise)
            .WithMany()
            .HasForeignKey(te => te.ExerciseId);

        modelBuilder.Entity<TrainingSessionExercise>()
            .HasOne(tse => tse.Exercise)
            .WithMany()
            .HasForeignKey(tse => tse.ExerciseId);

        // Map entities to tables
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Exercise>().ToTable("exercises");
        modelBuilder.Entity<Training>().ToTable("training");
        modelBuilder.Entity<TrainingSession>().ToTable("training_sessions");
        modelBuilder.Entity<TrainingExercise>().ToTable("training_exercises");
        modelBuilder.Entity<TrainingSessionExercise>().ToTable("training_session_exercises");
    }

    // DbSets for entities
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Training> training { get; set; }
    public DbSet<TrainingExercise> TrainingExercise { get; set; }
    public DbSet<TrainingSession> TrainingSession { get; set; }
    public DbSet<TrainingSessionExercise> TrainingSessionExercise { get; set; }
}
