using Core.MyCollections;
using Core.Entitys;
using Examples;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern;
using RepositoryPattern.Implementation;
internal class Program
{

    private static void Main(string[] args)
    {
        //Delegates.Run();
        //HashSet.Run();
        //MyCollection.UseMyList();
        //MyCollection.UseMyDictionary();
        //MyCollection.UseMyLinkedList();
        //MyCollection.UseMyQueue();
        //MyCollection.UseMySteck();

        //Reflection.Run();
        //Repository.UseRepositoryPattern(900000000);
        //Expressions.Run();
        Benchmarker.Run();


        Console.WriteLine("Hello, World!");
        Console.ReadLine();
    }
}