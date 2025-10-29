namespace hw_1
{
    public abstract class Vehicle : Car
    {
        public string WheelDrive;
        public string Class;
        public string Color;
    }

    public abstract class Cargo : Car
    {
        public double Tonnage;
        public double TankVolume;
        public int AxlesAmount;
    }

    public abstract class Tank : Car
    {
        public double ProjectileCaliber;
        public int ShotsPerMinute;
        public int CrewSize;
    }
}
