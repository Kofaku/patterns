namespace hw_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();

            Vehicle car1 = new Vehicle
            {
                Name = "Седан",
                Weight = 1500,
                Length = 4.5,
                MaxSpeed = 180,
                WheelDrive = "Передний",
                Class = "Седан",
                Color = "Красный"
            };

            Cargo truck1 = new Cargo
            {
                Name = "Грузовик",
                Weight = 5000,
                Length = 8.0,
                MaxSpeed = 120,
                Tonnage = 10,
                TankVolume = 200,
                AxlesAmount = 3
            };

            Tank tank1 = new Tank
            {
                Name = "Танк Т-90",
                Weight = 46000,
                Length = 9.5,
                MaxSpeed = 60,
                ProjectileCaliber = 125,
                ShotsPerMinute = 8,
                CrewSize = 3
            };

            container.AddCar(car1);
            container.AddCar(truck1);
            container.AddCar(tank1);

            Console.WriteLine();
            car1.Color = "Синий";                   
            truck1.Tonnage = 12;                     
            tank1.CrewSize = 4;                      
            car1.Weight = 1550;                     

            Console.WriteLine();
            container.ShowAllCarsInfo();
        }
    }
}