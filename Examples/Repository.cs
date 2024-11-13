using Core;
using Core.Entitys;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern;
using RepositoryPattern.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Repository
    {
        public static void UseRepositoryPattern(int count)
        {
            var service = new ServiceCollection();
            service.AddRepositories(new()
                    {
                        {nameof(Student),cnf=>{ cnf.FileName = nameof(Student); cnf.StoreType = StoreType.OnEntityFramework; } },
                        {nameof(Customer),cnf=>{ cnf.FileName = nameof(Customer); cnf.StoreType = StoreType.OnEntityFramework; } },
                    });
            var Provider = service.BuildServiceProvider();


            var stRepository = Provider.GetRequiredService<IStutentRepository>();

            Run<Student>(stRepository, count);
            

            var cuRepository = Provider.GetRequiredService<ICustomerRepository>();

            Run<Customer>(cuRepository, count);


        }


        private static void Run<T>(IBaseRepository<T, int> repository, int count) where T : class, IPerson, new()
        {
            foreach (T item in Core.Generator.Generate<T>(count))
            {
                repository.Insert(item);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            repository.Save();

            // Stop measuring time
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine($"Elapsed Time: {elapsed.TotalMilliseconds} ms");
        }
    }
}
