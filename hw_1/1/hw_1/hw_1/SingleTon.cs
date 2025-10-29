namespace Patterns
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {
            Console.WriteLine("Singleton создан");
        }

        public static Singleton Instance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            
            return _instance;
        }

        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
}