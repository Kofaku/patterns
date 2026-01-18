namespace hw_3_3
{
    public class Vehicle : Car
    {
        private string _wheelDrive;
        private string _class;
        private string _color;

        public string WheelDrive
        {
            get => _wheelDrive;
            set
            {
                if (_wheelDrive != value)
                {
                    string oldValue = _wheelDrive;
                    _wheelDrive = value;
                    OnPropertyChanged(nameof(WheelDrive), oldValue, value);
                }
            }
        }

        public string Class
        {
            get => _class;
            set
            {
                if (_class != value)
                {
                    string oldValue = _class;
                    _class = value;
                    OnPropertyChanged(nameof(Class), oldValue, value);
                }
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    string oldValue = _color;
                    _color = value;
                    OnPropertyChanged(nameof(Color), oldValue, value);
                }
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Транспорт: {Name}, Вес: {Weight}, Длина: {Length}, Макс. скорость: {MaxSpeed}, " +
                              $"Привод: {WheelDrive}, Класс: {Class}, Цвет: {Color}");
        }
    }
}