namespace hw2_1
{
    interface IColor
    {
        string Born();
    }
    class RedColor : IColor { public string Born() => "Рыжий"; }
    class BlackColor : IColor { public string Born() => "Черный"; }

    abstract class Pet
    {
        protected IColor _color;
        public Pet(IColor color) { _color = color; }
        public abstract void Feed();
    }

    class Cat : Pet
    {
        public Cat(IColor color) : base(color) { }
        public override void Feed()
        {
            Console.WriteLine($"{_color.Born()} кот покормлен");
        }
    }
    class Dog : Pet
    {
        public Dog(IColor color) : base(color) { }
        public override void Feed()
        {
            Console.WriteLine($"{_color.Born()} пёс покормлен");
        }
    }
}