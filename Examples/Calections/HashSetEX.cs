using Core.Entitys;
using System.Diagnostics.CodeAnalysis;


namespace Examples.Calections
{
    class PersonEqualityComparer : EqualityComparer<Person>
    {
        public override bool Equals(Person? x, Person? y) => x.Email == y.Email;

        public override int GetHashCode([DisallowNull] Person obj)
        {
            return obj.Email.GetHashCode();
        }
    }
    class HashSetEX
    {
        public static void Run()
        {

            var set = new HashSet<string>
            {
                "a",
                "a"
            };

            var equalityComparer = new PersonEqualityComparer();

            var setStutent = new HashSet<Student>(equalityComparer)
            {
                new() { Email = "adolf@gmail.com" },
                new() { Email = "adolf@gmail.com" }
            };


            var setCustomer = new HashSet<Customer>(equalityComparer)
            {
                new() { Email = "adolf@gmail.com" },
                new() { Email = "adolf@gmail.com" }
            };


            var setEmployer = new HashSet<Employer>(equalityComparer)
            {
                new() { Email = "adolf@gmail.com" },
                new() { Email = "adolf@gmail.com" }
            };
        }
    }
}
