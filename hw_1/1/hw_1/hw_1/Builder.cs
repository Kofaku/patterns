namespace Patterns
{
    public class Sandwich
    {
        public string Bread { get; set; }
        public string Vegetable { get; set; }
        public string Meat { get; set; }
        public string Cheese { get; set; }

        public void View()
        {
            Console.WriteLine($"Бутерброд: {Bread} + {Vegetable} + {Meat} + {Cheese}");
        }
    }

    public interface ISandwichBuilder
    {
        void BuildBread();
        void BuildVegetable();
        void BuildMeat();
        void BuildCheese();
        Sandwich GetSandwich();
    }

    public class CiabattaSandwichBuilder : ISandwichBuilder
    {
        private Sandwich _sandwich = new Sandwich();

        public void BuildBread() => _sandwich.Bread = "чиабатта";
        public void BuildVegetable() => _sandwich.Vegetable = "помидор и шпинат";
        public void BuildMeat() => _sandwich.Meat = "куриная грудка";
        public void BuildCheese() => _sandwich.Cheese = "моцарелла";

        public Sandwich GetSandwich() => _sandwich;
    }

    public class RyeSandwichBuilder : ISandwichBuilder
    {
        private Sandwich _sandwich = new Sandwich();

        public void BuildBread() => _sandwich.Bread = "ржаной";
        public void BuildVegetable() => _sandwich.Vegetable = "маринованный огурчик";
        public void BuildMeat() => _sandwich.Meat = "брискет";
        public void BuildCheese() => _sandwich.Cheese = "чеддер";

        public Sandwich GetSandwich() => _sandwich;
    }

    public class SandwichDirector
    {
        public Sandwich BuildSandwich(ISandwichBuilder builder)
        {
            builder.BuildBread();
            builder.BuildVegetable();
            builder.BuildMeat();
            builder.BuildCheese();
            return builder.GetSandwich();
        }
    }
}