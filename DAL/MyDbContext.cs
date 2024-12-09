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
        
        // Define your model configurations
        modelBuilder.Entity<User>()
            .HasIndex(a => a.Username).IsUnique();
        modelBuilder.Entity<Exercise>()
            .HasIndex(e => e.Name).IsUnique();

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
        modelBuilder.Entity<Training>().ToTable("training");
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Training>().HasKey(t => t.TrainingId);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Training> training { get; set; }
    public DbSet<TrainingExercise> TrainingExercise { get; set; }
    public DbSet<TrainingSession> TrainingSession { get; set; }
    public DbSet<TrainingSessionExercise> TrainingSessionExercise { get; set; }
}