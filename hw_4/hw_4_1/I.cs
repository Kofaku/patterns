namespace hw_4_1
{
    public interface IAnimalActivity
    {
        void Eat();
        void Run();
        void Swim();
        void Fly();
    }

    public class Fish : IAnimalActivity
    {
        public void Eat() { Console.WriteLine("Рыбка ест планктон"); }
        public void Swim() { Console.WriteLine("Рыбка плывет"); }
        public void Run() { Console.WriteLine("Рыбка бегать не умеет("); }
        public void Fly() { Console.WriteLine("Рыбка летать  не умеет("); }
    }
}