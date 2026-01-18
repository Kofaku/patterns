namespace hw_3_3
{
    public class Container
    {
        private List<Car> _cars = new List<Car>();

        public void AddCar(Car car)
        {
            car.PropertyChanged += Car_PropertyChanged;

            _cars.Add(car);

            Console.WriteLine($"Добавлен экземпляр класса: {car.GetType().Name}");
        }

        private void Car_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Car car = (Car)sender;

            Console.WriteLine($"Класс: {car.GetType().Name}, Свойство: {e.PropertyName}, " +
                             $"Старое значение: {e.OldValue}, Новое значение: {e.NewValue}");
        }

        public void ShowAllCarsInfo()
        {
            foreach (var car in _cars)
            {
                car.ShowInfo();
            }
        }
    }
}