using Core.Entitys;
using DesignPatterns.Repository.StorageՕptions;

namespace Examples
{
    public class ReflectionEX
    {
        public static void Run()
        {
            var person = Core.Generator.Generate<Person>(4);
            var stutents = Core.Generator.Generate<Student>(4);
            var customer = Core.Generator.Generate<Customer>(4);
            var employer = Core.Generator.Generate<Employer>(4);
            var listOfInt = new List<int>();
            for (int i = 1; i <= 4; i++)
            {
                listOfInt.Add(i);
            }

            OnXml.WriteByReflection(person, nameof(Person));
            OnXml.WriteByReflection(stutents, nameof(Student));
            OnXml.WriteByReflection(customer, nameof(Customer));
            OnXml.WriteByReflection(employer, nameof(Employer));
            OnXml.WriteByReflection(listOfInt, nameof(Int32));
        }
    }
}
