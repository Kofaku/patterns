using hw_4_1;

class Program
{
    static void Main (string[] args)
    {
        //S
        Animal animal = new Animal("Пушок", "Кот");
        animal.Eat();
        animal.SaveToDatabase();
        Console.WriteLine();
        //O
        AnimalSound animalSound = new AnimalSound();
        animalSound.MakeSound("Кот");
        animalSound.MakeSound("Птица");
        Console.WriteLine();
        //L
        var calculator = new AreaCalculator();
        calculator.TestRectangleArea();
        Console.WriteLine();
        //I
        Fish fish = new Fish();
        fish.Eat();
        fish.Swim();
        fish.Fly();
        fish.Run();
        Console.WriteLine();
        //D
        Feeder feeder = new Feeder();
        feeder.FeedCat();
    }
}