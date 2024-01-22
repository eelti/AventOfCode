using day05;
using Microsoft.EntityFrameworkCore;
    
    public class MyDbContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }
        public DbSet<SeedMapper> SeedMappers { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDb)\MSSQLLocalDB;Database=MyDatabase;Integrated Security=True");
        }
    }
    