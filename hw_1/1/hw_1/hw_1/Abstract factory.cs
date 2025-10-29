namespace Patterns
{
    public interface IPetsFactory
    {
        IDog CreateDog();
        IRabbit CreateRabbit();
    }

    public interface IDog
    {
        void Pet();
    }

    public interface IRabbit
    {
        void Pet();
    }

    public class BlackDog : IDog
    {
        public void Pet() => Console.WriteLine("Поглажена черная собака");
    }

    public class BlackRabbit : IRabbit
    {
        public void Pet() => Console.WriteLine("Поглажен черный кролик");
    }

    public class WhiteDog : IDog
    {
        public void Pet() => Console.WriteLine("Поглажена белая собака");
    }

    public class WhiteRabbit : IRabbit
    {
        public void Pet() => Console.WriteLine("Поглажен белый кролик");
    }

    public class BlackPets : IPetsFactory
    {
        public IDog CreateDog() => new BlackDog();
        public IRabbit CreateRabbit() => new BlackRabbit();
    }

    public class WhitePets : IPetsFactory
    {
        public IDog CreateDog() => new WhiteDog();
        public IRabbit CreateRabbit() => new WhiteRabbit();
    }

    public class Application
    {
        private IPetsFactory _factory;
        private IDog _dog;
        private IRabbit _rabbit;

        public Application(IPetsFactory factory)
        {
            _factory = factory;
        }

        public void CreatePets()
        {
            _dog = _factory.CreateDog();
            _rabbit = _factory.CreateRabbit();
        }

        public void PetPets()
        {
            _dog.Pet();
            _rabbit.Pet();
        }
    }
}