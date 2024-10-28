using Core.Entitys;
using System.Diagnostics.CodeAnalysis;


namespace Examples
{
    class PersonEqualityComparer : EqualityComparer<Person>
    {
        public override bool Equals(Person? x, Person? y) => x.Email == y.Email;

        public override int GetHashCode([DisallowNull] Person obj)
        {
            return obj.Email.GetHashCode();
        }
    }
    class HashSet
    {
        public static void Run()
        {

            var set = new HashSet<string>();
            set.Add("a");
            set.Add("a");

            var equalityComparer = new PersonEqualityComparer();

            var setStutent = new HashSet<Student>(equalityComparer);
            setStutent.Add(new Student() { Email = "adolf@gmail.com" });
            setStutent.Add(new Student() { Email = "adolf@gmail.com" });


            var setCustomer = new HashSet<Customer>(equalityComparer);
            setCustomer.Add(new Customer() { Email = "adolf@gmail.com" });
            setCustomer.Add(new Customer() { Email = "adolf@gmail.com" });


            var setEmployer = new HashSet<Employer>(equalityComparer);
            setEmployer.Add(new Employer() { Email = "adolf@gmail.com" });
            setEmployer.Add(new Employer() { Email = "adolf@gmail.com" });
        }
    }
}
