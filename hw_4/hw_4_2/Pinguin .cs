namespace hw_4_2
{
    public class Pinguin : IMovable, IMultipliable, IParent
    {
        public void Walk()
        {
            Console.WriteLine("Pinguin: Walk");
        }

        public void SearchForSpouse()
        {
            Console.WriteLine("Pinguin: Search for spouse");
        }

        public void Sing()
        {
            Console.WriteLine("Pinguin: Sing");
        }

        public void Dance()
        {
            Console.WriteLine("Pinguin: Dance");
        }

        public void ProduceEgg()
        {
            Console.WriteLine("Pinguin: Produce egg");
        }

        public void DefendEgg()
        {
            Console.WriteLine("Pinguin: Defend egg");
        }
    }
}
