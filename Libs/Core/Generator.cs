using Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Generator
    {
        public static List<T> Generate<T>(int count) where T : class , IPerson, new()
        {
            var items = new List<T>();

            for (int i = 1; i <= count; i++)
            {

                var item = new T()
                {
                    ID = GenereteID(),
                    Name = $"Name{i}",
                    Email = $"{i}@gmail.com",
                    Phone = $"+374 {i}",
                    Age = i
                };

                switch (item)
                {
                    case Student student:
                        student.Pension = i * 1000;
                        break;
                    case Customer customer:
                        customer.Discount = i * 1000;
                        break;
                    case Employer employer:
                        employer.Salary = i * 1000;
                        break;
                }

                items.Add(item);
            }
            return items;
        }

        public static int GenereteID()
        {
            return new Random().Next(10001, 99999);
        }
    }
}
