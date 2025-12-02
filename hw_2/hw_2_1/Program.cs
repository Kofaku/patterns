namespace hw2_1
{

    class Program
    {
        static void Main()
        {
            //Adapter
            OldClass myoldClass = new OldClass();
            IModernInterface adaptedClass = new SomeAdapter(myoldClass);
            adaptedClass.Start();
            Console.WriteLine();

            //Bridge
            Pet redCat = new Cat(new RedColor());
            Pet blackDog = new Dog(new BlackColor());
            redCat.Feed();
            blackDog.Feed();
            Console.WriteLine();

            //Composite
            var phone = new SingleProduct(1000);
            var charger = new SingleProduct(50);
            var headphones = new SingleProduct(200);
            var smallBox = new BoxOfProducts();
            smallBox.Add(phone);
            smallBox.Add(charger);
            var bigBox = new BoxOfProducts();
            bigBox.Add(smallBox);
            bigBox.Add(headphones);
            Console.WriteLine($"Цена всех товаров: {bigBox.GetPrice()}");
            Console.WriteLine();

            //Decorator
            IBoxGiver giver = new SimpleGiver();
            giver.Give("Коробка");
            IBoxGiver bowKnotGiver = new BowKnotDecorator(new SimpleGiver());
            bowKnotGiver.Give("Коробка с бантом");
            IBoxGiver bowPaperGiver = new WrappingPaperDecorator(new BowKnotDecorator(new SimpleGiver()));
            bowPaperGiver.Give("Коробка в бумаге и с бантом");
            Console.WriteLine();

            //Facade
            ComputerFacade myComputer = new ComputerFacade();
            myComputer.PressPowerButton();
            Console.WriteLine();

            //Flyweight
            TreeType oakType = TreeFactory.GetTreeType("Дуб", "Зеленый", "Дубовая текстура");
            TreeType mapleType = TreeFactory.GetTreeType("Клен", "Красный", "Кленовая текстура");
            Tree tree1 = new Tree(10, 20, oakType);
            Tree tree2 = new Tree(15, 25, oakType);
            Tree tree3 = new Tree(20, 30, mapleType);
            tree1.Draw();
            tree2.Draw();
            tree3.Draw();
            Console.WriteLine();

            //Proxy
            IImage image = new ProxyImage("photo1234.jpg");
            image.Display();
        }
    }
}
