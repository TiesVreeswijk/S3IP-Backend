using Microsoft.EntityFrameworkCore;


namespace DAL;

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }


    public DbSet<UserModel> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define your model configurations
        modelBuilder.Entity<UserModel>()
            .HasIndex(a => a.Username).IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}