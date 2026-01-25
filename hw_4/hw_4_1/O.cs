namespace hw_4_1
{
    public class AnimalSound
    {
        public void MakeSound(string animalType)
        {
            if (animalType == "Собака")
                Console.WriteLine("Гав!");
            else if (animalType == "Кот")
                Console.WriteLine("Мяу!");
            else
                Console.WriteLine("...");
        }
    }
}