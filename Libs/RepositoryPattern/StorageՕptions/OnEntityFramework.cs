using Core.Entitys;
using Microsoft.EntityFrameworkCore;
namespace RepositoryPattern.StorageՕptions
{
    internal class UniversityDbContext : DbContext
    {
        private readonly string _connectionString;
        public UniversityDbContext(string connectionString) 
        {
            _connectionString = connectionString;
        }
        public DbSet<Core.Entitys.Student> Students { get; set; }
        public DbSet<Core.Entitys.Employer> Employers { get; set; }
        public DbSet<Core.Entitys.Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set up connection string and database provider (SQLite in this case)
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    internal class OnEntityFramework
    {
        public static string connectionString;
        internal static IEnumerable<T> Load<T>() 
        {

            using (var context = new UniversityDbContext(connectionString))
            {
                // Ensure the database is created
                context.Database.EnsureCreated();


                switch (typeof(T).Name)
                {
                    case (nameof(Student)):
                        return context.Students.ToList() as List<T>;
                    case (nameof(Customer)):
                        return context.Customers.ToList() as List<T>;
                    case (nameof(Employer)):
                        return context.Employers.ToList() as List<T>;
                    default:
                        break;
                }
            }
            return new List<T>();
        }

        internal static void Write<T>(List<T> source) 
        {
            using (var context = new UniversityDbContext(connectionString))
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Add the student to the database
                foreach (var Data in source)
                {
                    switch (typeof(T).Name)
                    {
                        case (nameof(Student)):
                            context.Students.Add(Data as Student);
                            break;
                        case (nameof(Customer)):
                            context.Customers.Add(Data as Customer);
                            break;
                        case (nameof(Employer)):
                            context.Employers.Add(Data as Employer);
                            break;
                        default:
                            break;
                    }
                }
                context.SaveChanges();

                //// Display all students
                //var students = context.Students.ToList();
                //Console.WriteLine("All Students:");
                //foreach (var student in students)
                //{
                //    Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}, Date of Birth: {student.DateOfBirth}");
                //}
            }
        }

    }
}
