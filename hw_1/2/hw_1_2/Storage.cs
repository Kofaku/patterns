namespace hw_1
{
    public class TransportStorage
    {
        private static TransportStorage instance;
        public List<Car> Items = new();
        public static TransportStorage Instance => instance ??= new TransportStorage();
    }
}
