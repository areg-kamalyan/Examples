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
        public DbSet<Student> Students { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Customer> Customers { get; set; }

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

                switch (typeof(T).Name)
                {
                    case (nameof(Student)):
                        {
                            var Data = source as List<Student>;
                            var id = context.Students.Select(s => s.ID).ToList();
                            var Addeble = Data.Where(d => !id.Exists(s => d.ID == s));
                            var Updateeble = Data.Where(d => id.Exists(s => d.ID == s));
                            context.Students.AddRange(Addeble);
                            context.Students.UpdateRange(Updateeble);
                            break;
                        }
                    case (nameof(Customer)):
                        {
                            var Data = source as List<Customer>;
                            var id = context.Customers.Select(s => s.ID).ToList();
                            var Addeble = Data.Where(d => !id.Exists(s => d.ID == s));
                            var Updateeble = Data.Where(d => id.Exists(s => d.ID == s));
                            context.Customers.AddRange(Addeble);
                            context.Customers.UpdateRange(Updateeble);
                            break;
                        }
                    case (nameof(Employer)):
                        {
                            var Data = source as List<Employer>;
                            var id = context.Employers.Select(s => s.ID).ToList();
                            var Addeble = Data.Where(d => !id.Exists(s => d.ID == s));
                            var Updateeble = Data.Where(d => id.Exists(s => d.ID == s));
                            context.Employers.AddRange(Addeble);
                            context.Employers.UpdateRange(Updateeble);
                            break;
                        }
                    default:
                        break;
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
