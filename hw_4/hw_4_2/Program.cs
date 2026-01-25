namespace hw_4_2
{
    class Program
    {
        static void Main(string[] args)
        {

            var birdFactory = new BirdFactory();
            var birdHandler = new BirdHandler(birdFactory);

            birdHandler.DoBirdAction("Sparrow");
            Console.WriteLine();
            birdHandler.DoBirdAction("Pinguin");
            Console.WriteLine();
            birdHandler.DoBirdAction("Chicken");
        }
    }
}