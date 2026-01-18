namespace hw_3_3
{
    public class Cargo : Car
    {
        private double _tonnage;
        private double _tankVolume;
        private int _axlesAmount;

        public double Tonnage
        {
            get => _tonnage;
            set
            {
                if (_tonnage != value)
                {
                    double oldValue = _tonnage;
                    _tonnage = value;
                    OnPropertyChanged(nameof(Tonnage), oldValue, value);
                }
            }
        }

        public double TankVolume
        {
            get => _tankVolume;
            set
            {
                if (_tankVolume != value)
                {
                    double oldValue = _tankVolume;
                    _tankVolume = value;
                    OnPropertyChanged(nameof(TankVolume), oldValue, value);
                }
            }
        }

        public int AxlesAmount
        {
            get => _axlesAmount;
            set
            {
                if (_axlesAmount != value)
                {
                    int oldValue = _axlesAmount;
                    _axlesAmount = value;
                    OnPropertyChanged(nameof(AxlesAmount), oldValue, value);
                }
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Грузовик: {Name}, Вес: {Weight}, Длина: {Length}, Макс. скорость: {MaxSpeed}, " +
                              $"Тоннаж: {Tonnage}, Объем бака: {TankVolume}, Оси: {AxlesAmount}");
        }
    }
}