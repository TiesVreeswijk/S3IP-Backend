using Microsoft.EntityFrameworkCore;


namespace DAL;

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }


    public DbSet<UserModel> User { get; set; }
    public DbSet<ExerciseModel> Exercise { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define your model configurations
        modelBuilder.Entity<UserModel>()
            .HasIndex(a => a.Username).IsUnique();
        modelBuilder.Entity<ExerciseModel>()
            .HasIndex(e => e.Name).IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}