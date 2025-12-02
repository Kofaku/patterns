namespace hw2_1
{
    interface IImage
    {
        void Display();
    }

    class RealImage : IImage
    {
        private string _filename;
        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk();
        }
        private void LoadFromDisk()
        {
            Console.WriteLine($"Загружаю тяжелое изображение '{_filename}' с диска...");
        }
        public void Display()
        {
            Console.WriteLine($"Показываю изображение '{_filename}'");
        }
    }

    class ProxyImage : IImage
    {
        private RealImage _realImage;
        private string _filename;

        public ProxyImage(string filename)
        {
            _filename = filename;
        }
        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_filename);
            }
            _realImage.Display();
        }
    }
}