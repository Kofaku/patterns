namespace hw_4_1
{
    public class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Animal(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} кушает.");
        }

        public void SaveToDatabase()
        {
            Console.WriteLine($"Сохраняю {Name} в базу...");
        }
    }
}