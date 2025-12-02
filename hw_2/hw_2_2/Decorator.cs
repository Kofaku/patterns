namespace hw2_2
{
    public interface IFlexibleClient
    {
        List<SomeEntity> GetMany();
        List<SomeEntity> GetByFilter(string filter);
    }

    public class FlexibleClient : IFlexibleClient
    {
        private readonly SomeEntityApiController _apiController;

        public FlexibleClient(SomeEntityApiController apiController)
        {
            _apiController = apiController;
        }

        public List<SomeEntity> GetMany()
        {
            return _apiController.GetMany();
        }

        public List<SomeEntity> GetByFilter(string filter)
        {
            return _apiController.GetByFilter(filter);
        }
    }

    public class CachingFlexibleClient : IFlexibleClient
    {
        private readonly IFlexibleClient _client;
        private Dictionary<string, List<SomeEntity>> _cache = new();

        public CachingFlexibleClient(IFlexibleClient client)
        {
            _client = client;
        }

        public List<SomeEntity> GetMany()
        {
            const string key = "all";
            if (_cache.ContainsKey(key))
            {
                Console.WriteLine("Возвращаю данные из кэша");
                return _cache[key];
            }

            var result = _client.GetMany();
            _cache[key] = result;
            return result;
        }

        public List<SomeEntity> GetByFilter(string filter)
        {
            if (_cache.ContainsKey(filter))
            {
                Console.WriteLine("Возвращаю отфильтрованные данные из кэша");
                return _cache[filter];
            }

            var result = _client.GetByFilter(filter);
            _cache[filter] = result;
            return result;
        }
    }
}
