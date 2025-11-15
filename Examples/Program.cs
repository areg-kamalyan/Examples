using Examples;
using Examples.Calections;
using Examples.Paterns;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        //DelegatesEX.Run();
        //HashSetEX.Run();

        //ReflectionEX.Run();
        //ExpressionsEX.Run();
        //BenchmarkerEX.Run();

        Repository.Use(9000);
        //Bilder.Use();
        //Singleton.Use();

        //SemaphoreEX.Run();
        //ThreadPoolEx.Run();

        //DelegatesEX.Run();
        //EventsEX.Run();

        //ImmutableCollectionsEx.Ran();

        //RecordEx.Run();

        Console.WriteLine("Examples End");
        Console.ReadLine();
    }
}