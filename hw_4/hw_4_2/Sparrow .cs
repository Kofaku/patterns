namespace hw_4_2
{
    public class Sparrow : IMovable, IFlyable, IMultipliable, IParent
    {
        public void Walk()
        {
            Console.WriteLine("Sparrow: Walk");
        }

        public void Fly()
        {
            Console.WriteLine("Sparrow: Fly");
        }

        public void SearchForSpouse()
        {
            Console.WriteLine("Sparrow: Search for spouse");
        }

        public void Sing()
        {
            Console.WriteLine("Sparrow: Sing");
        }

        public void Dance()
        {
            Console.WriteLine("Sparrow: Dance");
        }

        public void ProduceEgg()
        {
            Console.WriteLine("Sparrow: Produce egg");
        }

        public void DefendEgg()
        {
            Console.WriteLine("Sparrow: Defend egg");
        }
    }
}

