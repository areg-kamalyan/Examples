using Core.Collections;
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
        //Reflection.Run();
        Repository.UseRepositoryPattern();
        //Expressions.Run();


        Console.WriteLine("Hello, World!");
    }
}