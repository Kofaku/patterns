namespace hw_4_2
{
    public interface IBirdFactory
    {
        object CreateBird(string birdType);
    }

    public class BirdFactory : IBirdFactory
    {
        public object CreateBird(string birdType)
        {
            return birdType switch
            {
                "Pinguin" => new Pinguin(),
                "Sparrow" => new Sparrow(),
                _ => throw new ArgumentException($"Unknown bird type: {birdType}")
            };
        }
    }

}
