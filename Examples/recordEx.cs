using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public record PersonRecord(string Name, int Age);
    public record struct Point(int X, int Y);

    internal class RecordEx
    {
        public static void Run()
        {
            var r1 = new PersonRecord("Alice", 30);
            var r2 = new PersonRecord("Alice", 30);

            Console.WriteLine(r1 == r2);

            var p1 = new Point(25, 30);
            var p2 = new Point(25, 30);

            Console.WriteLine(p1 == p2);
        }
    }
}
