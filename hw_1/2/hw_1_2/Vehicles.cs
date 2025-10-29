namespace hw_1
{
    public class Audi : Vehicle
    {
        public Audi()
        {
            Name = "Audi A4";
            Weight = 1500;
            Length = 4.7;
            MaxSpeed = 210;
            WheelDrive = "Quattro";
            Class = "sedan";
            Color = "black";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: {Color}, drive={WheelDrive}, class={Class}, speed={MaxSpeed}");
    }

    public class Honda : Vehicle
    {
        public Honda()
        {
            Name = "Honda Civic";
            Weight = 1300;
            Length = 4.5;
            MaxSpeed = 200;
            WheelDrive = "Front";
            Class = "hatchback";
            Color = "white";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: {Color}, drive={WheelDrive}, class={Class}, speed={MaxSpeed}");
    }

    public class Tesla : Vehicle
    {
        public Tesla()
        {
            Name = "Tesla Model 3";
            Weight = 1600;
            Length = 4.8;
            MaxSpeed = 225;
            WheelDrive = "AWD";
            Class = "sedan";
            Color = "red";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"{Name}: {Color}, drive={WheelDrive}, class={Class}, speed={MaxSpeed}");
    }

}
