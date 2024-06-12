using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<Customers> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"UserID=postgres;Password=docker;Host=localhost;Port=5432;Database=finance;Pooling=true;");
        }
    }
}
