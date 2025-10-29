using hw_1;
#pragma warning disable CS8600 
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Создать транспорт");
            Console.WriteLine("2. Показать список");
            Console.WriteLine("3. Удалить по номеру");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");

            switch (Console.ReadLine())
            {
                case "1": CreateMenu(); break;
                case "2": ShowAll(); break;
                case "3": DeleteMenu(); break;
                case "0": return;
            }
        }
    }

    static void CreateMenu()
    {
        Console.WriteLine("Выберите тип:");
        Console.WriteLine("1. Легковой автомобиль");
        Console.WriteLine("2. Грузовик");
        Console.WriteLine("3. Танки");
        Console.Write("Выбор: ");

        string type = Console.ReadLine();

        TransportFactory factory = type switch
        {
            "1" => new VehicleFactory(),
            "2" => new CargoFactory(),
            "3" => new TankFactory(),
            _ => null
        };

        if (factory == null) return;

        Console.WriteLine("\nВыберите модель:");
        if (type == "1")
            Console.WriteLine("1. Audi\n2. Honda\n3. Tesla");
        else if (type == "2")
            Console.WriteLine("1. Volvo\n2. Man\n3. Scania");
        else
            Console.WriteLine("1. Abrams\n2. Merkava\n3. Tiger");

        Console.Write("Выбор: ");

        if (int.TryParse(Console.ReadLine(), out int sel))
        {
            Car obj = factory.Create(sel);
            if (obj != null)
            {
                TransportStorage.Instance.Items.Add(obj);
                Console.WriteLine("Создано!");
            }
        }
    }

    static void ShowAll()
    {
        if (TransportStorage.Instance.Items.Count == 0)
        {
            Console.WriteLine("Список пуст!");
            return;
        }

        for (int i = 0; i < TransportStorage.Instance.Items.Count; i++)
        {
            Console.Write($"{i}: ");
            TransportStorage.Instance.Items[i].ShowInfo();
        }
    }

    static void DeleteMenu()
    {
        ShowAll();
        Console.Write("Введите номер: ");

        if (int.TryParse(Console.ReadLine(), out int i) &&
            i >= 0 && i < TransportStorage.Instance.Items.Count)
        {
            TransportStorage.Instance.Items.RemoveAt(i);
            Console.WriteLine("Удалено!");
        }
        else
            Console.WriteLine("Неверный номер!");
    }
}
