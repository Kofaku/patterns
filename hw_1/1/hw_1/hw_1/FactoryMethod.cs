namespace Patterns
{
    public abstract class CatCreator
    {
        public abstract ICat CreateCat();

        public void NewCat()
        {
            var cat = CreateCat();
            cat.Pet();
            cat.Kiss();
        }
    }

    public interface ICat
    {
        void Pet();
        void Kiss();
    }

    public class RedCat : ICat
    {
        public void Pet() => Console.WriteLine("Рыжий кот поглажен");
        public void Kiss() => Console.WriteLine("Рыжий кот поцелован");
    }

    public class BlackCat : ICat
    {
        public void Pet() => Console.WriteLine("Черный кот поглажен");
        public void Kiss() => Console.WriteLine("Черный кот поцелован");
    }

    public class RedCreator : CatCreator
    {
        public override ICat CreateCat() => new RedCat();
    }

    public class BlackCreator : CatCreator
    {
        public override ICat CreateCat() => new BlackCat();
    }
}