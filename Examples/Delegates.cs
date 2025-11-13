using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Delegates
    {

        public static void Run()
        {
            var item = new Delegates();
            List<int> list = new List<int>() { 15, 77, 1500, 1456, 12669, 152, 5234, 1231, 222, 5423, 1114 };

            // **************Delegate**********************

            //D_1 d_1 = new D_1(item.FN1);
            D_1 d_1 = item.FN1;
            d_1.Invoke();

            // **************Action**********************
            Action SA = item.FN1;
            SA.Invoke();

            // **************Func**********************
            Func<int> SD = item.FN2;
            SD.Invoke();

            //var zz = list.MyEven().MyGreaterThan(600);
            var zz = list.Operation(i => i > 600 && i % 2 == 0);
            foreach (int i in zz)
            {
                Console.WriteLine(i);
            }

            // **************Predicate**********************
            Predicate<string> isUpper = IsUpperCase;
            isUpper.Invoke("ARA");

            // **************Collback**********************

            Action<string> callback = message => Console.WriteLine(message);
            item.DoSomethingSynchronously(callback);
        }

        public delegate void D_1();

        public void FN1() 
        {
            Console.WriteLine("print FN1");
        }

        public int FN2()
        {
            Console.WriteLine("print FN2");
            return 0;
        }

        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        public void DoSomethingSynchronously(Action<string> callback)
        {
            // Simulate a time-consuming operation
            for (int i = 0; i < 5; i++)
            {
                callback($"Iteration {i}");
                Thread.Sleep(1000); // Simulate work
            }
        }
    }


    public static partial class Extations
    {
        public static IEnumerable<int> MyGreaterThan(this IEnumerable<int> arr, int value)
        {
            foreach (int i in arr)
                if (i > value)
                    yield return i;
        }

        public static IEnumerable<int> MyEven(this IEnumerable<int> arr)
        {
            foreach (int i in arr)
                if (i % 2 == 0)
                    yield return i;
        }

        public static IEnumerable<T> Operation<T>(this IEnumerable<T> arr, Func<T, bool> func)
        {
            foreach (T i in arr)
                if (func.Invoke(i))
                    yield return i;
        }

    }
}
