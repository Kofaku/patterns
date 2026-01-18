using System.ComponentModel;

namespace hw_3_3
{
    public abstract class Car
    {
        private double _weight;
        private double _length;
        private double _maxSpeed;
        private string _name;

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    double oldValue = _weight;
                    _weight = value;
                    OnPropertyChanged(nameof(Weight), oldValue, value);
                }
            }
        }

        public double Length
        {
            get => _length;
            set
            {
                if (_length != value)
                {
                    double oldValue = _length;
                    _length = value;
                    OnPropertyChanged(nameof(Length), oldValue, value);
                }
            }
        }

        public double MaxSpeed
        {
            get => _maxSpeed;
            set
            {
                if (_maxSpeed != value)
                {
                    double oldValue = _maxSpeed;
                    _maxSpeed = value;
                    OnPropertyChanged(nameof(MaxSpeed), oldValue, value);
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    string oldValue = _name;
                    _name = value;
                    OnPropertyChanged(nameof(Name), oldValue, value);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName, oldValue, newValue));
        }

        public abstract void ShowInfo();
    }
}
