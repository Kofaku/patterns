
namespace hw_1
{
    public class Volvo : Cargo
    {
        public Volvo()
        {
            Name = "Volvo FH";
            Weight = 9000;
            Length = 7.2;
            MaxSpeed = 120;
            Tonnage = 18;
            TankVolume = 600;
            AxlesAmount = 3;
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: {Tonnage}t, Axles={AxlesAmount}, Tank={TankVolume}, speed={MaxSpeed}");
    }

    public class Man : Cargo
    {
        public Man()
        {
            Name = "MAN TGX";
            Weight = 9500;
            Length = 7.4;
            MaxSpeed = 115;
            Tonnage = 20;
            TankVolume = 650;
            AxlesAmount = 4;
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: {Tonnage}t, Axles={AxlesAmount}, Tank={TankVolume}, speed={MaxSpeed}");
    }

    public class Scania : Cargo
    {
        public Scania()
        {
            Name = "Scania R-Series";
            Weight = 8800;
            Length = 7.1;
            MaxSpeed = 118;
            Tonnage = 17;
            TankVolume = 550;
            AxlesAmount = 3;
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: {Tonnage}t, Axles={AxlesAmount}, Tank={TankVolume}, speed={MaxSpeed}");
    }

}
