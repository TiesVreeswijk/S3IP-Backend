using Business.Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL;

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Training> Training { get; set; }
    public DbSet<TrainingExercise> TrainingExercise { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define your model configurations
        modelBuilder.Entity<User>()
            .HasIndex(a => a.Username).IsUnique();
        modelBuilder.Entity<Exercise>()
            .HasIndex(e => e.Name).IsUnique();
        modelBuilder.Entity<Training>()
            .HasMany(t => t.TrainingExercises)
            .WithOne(te => te.Training)
            .HasForeignKey(te => te.TrainingId);

        base.OnModelCreating(modelBuilder);
    }
}