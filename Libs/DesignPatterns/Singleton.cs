namespace DesignPatterns
{
    public class Singleton
    {
        private static Singleton? _instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get {
                if (_instance is null)
                    _instance = new Singleton();
                return _instance;
            }
        }
        public string DoSomething()
        {
            return "The DoSomething method is called!";
        }

    }
}
