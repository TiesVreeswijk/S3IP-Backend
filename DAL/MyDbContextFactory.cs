using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            // Define your connection string
            var connectionString = "server=localhost;database=liftmate;user=root;password=";

            // Create DbContextOptionsBuilder with the MySQL connection
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Return a new instance of MyDbContext
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}