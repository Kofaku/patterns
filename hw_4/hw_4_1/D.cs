namespace hw_4_1
{
    public class WhiskasCatFood 
    {
        public void Serve()
        {
            Console.WriteLine("Насыпаем Вискас.");
        }
    }

    public class Feeder
    {
        private WhiskasCatFood _food = new WhiskasCatFood();

        public void FeedCat()
        {
            _food.Serve();
        }
    }
}