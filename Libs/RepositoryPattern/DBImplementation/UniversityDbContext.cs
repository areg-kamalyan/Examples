using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace RepositoryPattern.DBImplementation
{
    internal class UniversityDbContext : DbContext
    {
        internal readonly static string connectionString = @"Server=(localdb)\ProjectModels;Database=UniversityDb;Trusted_Connection=True;Integrated Security=True";
        public DbSet<Core.Entitys.Student> Students { get; set; }
        public DbSet<Core.Entitys.Employer> Employers { get; set; }
        public DbSet<Core.Entitys.Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set up connection string and database provider (SQLite in this case)
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
