namespace hw_1
{
    public abstract class TransportFactory
    {
        public abstract Car Create(int selection);
    }

    public class VehicleFactory : TransportFactory
    {
        public override Car Create(int sel) =>
            sel switch
            {
                1 => new Audi(),
                2 => new Honda(),
                3 => new Tesla(),
                _ => null
            };
    }

    public class CargoFactory : TransportFactory
    {
        public override Car Create(int sel) =>
            sel switch
            {
                1 => new Volvo(),
                2 => new Man(),
                3 => new Scania(),
                _ => null
            };
    }

    public class TankFactory : TransportFactory
    {
        public override Car Create(int sel) =>
            sel switch
            {
                1 => new Abrams(),
                2 => new Merkava(),
                3 => new Tiger(),
                _ => null
            };
    }

}
