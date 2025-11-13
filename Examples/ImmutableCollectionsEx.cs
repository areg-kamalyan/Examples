using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    internal class ImmutableCollectionsEx
    {
        public static void Ran()
        {
            var list = ImmutableList.Create(1, 2, 3);
            var newList = list.Add(4);

            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine(string.Join(", ", newList));
        }
    }
}
