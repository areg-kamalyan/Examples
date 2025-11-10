
namespace Examples.Paterns
{
    internal class Singleton
    {
        public static void Use()
        {
            var _Singleton = DesignPatterns.Singleton.Instance;
            Console.WriteLine(_Singleton.DoSomething());
        }
    }
}
