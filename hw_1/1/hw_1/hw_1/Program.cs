using Patterns;
using System.Runtime;

class Program
{
    static void Main()
    {
        //SingleTon
        Singleton s1 = Singleton.Instance();
        Singleton s2 = Singleton.Instance();
        s1.Hello();
        s2.Hello();
        Console.WriteLine();

        //Factory Method
        CatCreator creator = new RedCreator();
        creator.NewCat();

        creator = new BlackCreator();
        creator.NewCat();
        Console.WriteLine();

        //Abstract Factory
        Application blackPets = new Application(new BlackPets());
        blackPets.CreatePets();
        blackPets.PetPets();

        Application whitePets = new Application(new WhitePets());
        whitePets.CreatePets();
        whitePets.PetPets();
        Console.WriteLine();

        //Builder
        SandwichDirector director = new SandwichDirector();

        ISandwichBuilder ciabattaBuilder = new CiabattaSandwichBuilder();
        Sandwich ciabattaSandwich = director.BuildSandwich(ciabattaBuilder);
        ciabattaSandwich.View();

        ISandwichBuilder ryeSandwichBuilder = new RyeSandwichBuilder();
        Sandwich ryeSandwich = director.BuildSandwich(ryeSandwichBuilder);
        ryeSandwich.View();
        Console.WriteLine();

        //Prototype

        Cat cat = new Cat();
        cat.SetValues(2, "Red", "Jack");
        cat.IdInfo = new IdInfo(1);
        Cat cat2 = cat.ShallowCopy();
        Cat cat3 = cat.DeepCopy();
        Console.WriteLine("Original values");
        Console.WriteLine($"      Name: {cat.Name}, Age: {cat.Age}, Color: {cat.Color}, ID: {cat.IdInfo.IdNumber} ");
        Console.WriteLine($"      Name: {cat2.Name}, Age: {cat2.Age}, Color: {cat2.Color}, ID: {cat2.IdInfo.IdNumber} ");
        Console.WriteLine($"      Name: {cat3.Name}, Age: {cat3.Age}, Color: {cat3.Color}, ID: {cat3.IdInfo.IdNumber} ");
        cat.SetValues(3, "Black", "Molly");
        cat.IdInfo.IdNumber = 2;
        Console.WriteLine("Values after changes");
        Console.WriteLine($"      Name: {cat.Name}, Age: {cat.Age}, Color: {cat.Color}, ID: {cat.IdInfo.IdNumber} ");
        Console.WriteLine($"      Name: {cat2.Name}, Age: {cat2.Age}, Color: {cat2.Color}, ID: {cat2.IdInfo.IdNumber} ");
        Console.WriteLine($"      Name: {cat3.Name}, Age: {cat3.Age}, Color: {cat3.Color}, ID: {cat3.IdInfo.IdNumber} ");
    }
}