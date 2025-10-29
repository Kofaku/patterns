namespace hw_1
{
    public class Abrams : Tank
    {
        public Abrams()
        {
            Name = "M1 Abrams";
            Weight = 62000;
            Length = 9.77;
            MaxSpeed = 67;
            ProjectileCaliber = 120;
            ShotsPerMinute = 6;
            CrewSize = 4;
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: caliber={ProjectileCaliber}, crew={CrewSize}, speed={MaxSpeed}");
    }

    public class Merkava : Tank
    {
        public Merkava()
        {
            Name = "Merkava Mk4";
            Weight = 65000;
            Length = 9.04;
            MaxSpeed = 64;
            ProjectileCaliber = 120;
            ShotsPerMinute = 8;
            CrewSize = 4;
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: caliber={ProjectileCaliber}, crew={CrewSize}, speed={MaxSpeed}");
    }

    public class Tiger : Tank
    {
        public Tiger()
        {
            Name = "Tiger II";
            Weight = 69000;
            Length = 10.3;
            MaxSpeed = 41;
            ProjectileCaliber = 88;
            ShotsPerMinute = 5;
            CrewSize = 5;
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: caliber={ProjectileCaliber}, crew={CrewSize}, speed={MaxSpeed}");
    }

}
