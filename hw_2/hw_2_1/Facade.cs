namespace hw2_1
{
    class PowerSupply
    {
        public void ProvidePower() => Console.WriteLine("Подаю питание");
    }
    class CPU
    {
        public void Initialize() => Console.WriteLine("Запускаю процессор");
    }
    class HardDrive
    {
        public void ReadBootSector() => Console.WriteLine("Читаю загрузочный сектор");
    }
    class OS
    {
        public void Load() => Console.WriteLine("Загружаю операционную систему");
    }

    class ComputerFacade
    {
        private PowerSupply _ps = new PowerSupply();
        private CPU _cpu = new CPU();
        private HardDrive _hdd = new HardDrive();
        private OS _os = new OS();

        public void PressPowerButton()
        {
            Console.WriteLine("Нажата кнопка питания");
            _ps.ProvidePower();
            _cpu.Initialize();
            _hdd.ReadBootSector();
            _os.Load();
            Console.WriteLine("Компьютер загружен");
        }
    }
}