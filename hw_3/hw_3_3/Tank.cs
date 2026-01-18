namespace hw_3_3
{
    public class Tank : Car
    {
        private double _projectileCaliber;
        private int _shotsPerMinute;
        private int _crewSize;

        public double ProjectileCaliber
        {
            get => _projectileCaliber;
            set
            {
                if (_projectileCaliber != value)
                {
                    double oldValue = _projectileCaliber;
                    _projectileCaliber = value;
                    OnPropertyChanged(nameof(ProjectileCaliber), oldValue, value);
                }
            }
        }

        public int ShotsPerMinute
        {
            get => _shotsPerMinute;
            set
            {
                if (_shotsPerMinute != value)
                {
                    int oldValue = _shotsPerMinute;
                    _shotsPerMinute = value;
                    OnPropertyChanged(nameof(ShotsPerMinute), oldValue, value);
                }
            }
        }

        public int CrewSize
        {
            get => _crewSize;
            set
            {
                if (_crewSize != value)
                {
                    int oldValue = _crewSize;
                    _crewSize = value;
                    OnPropertyChanged(nameof(CrewSize), oldValue, value);
                }
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Танк: {Name}, Вес: {Weight}, Длина: {Length}, Макс. скорость: {MaxSpeed}, " +
                              $"Калибр: {ProjectileCaliber}, Выстрел/минута: {ShotsPerMinute}, Экипаж: {CrewSize}");
        }
    }
}