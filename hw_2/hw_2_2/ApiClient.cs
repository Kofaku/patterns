namespace hw_2_2
{
    public interface ICrudClient<T>
    {
        Task<T> CreateAsync(T item);
        Task<T> ReadAsync(Guid id);
        Task UpdateAsync(T item);
        Task DeleteAsync(Guid id);
    }

    public class SomeEntityCrudClient : ICrudClient<SomeEntity>
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:5001/SomeEntity";

        public SomeEntityCrudClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SomeEntity> CreateAsync(SomeEntity item)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Create", item);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SomeEntity>();
        }

        public async Task<SomeEntity> ReadAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<SomeEntity>($"{BaseUrl}/GetOne/{id}");
        }

        public async Task UpdateAsync(SomeEntity item)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/Update", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

    public interface IFlexibleClient
    {
        Task<List<SomeEntity>> GetManyAsync();
        Task<List<SomeEntity>> GetByFilterAsync(Status? status);
    }

    public class FlexibleClient : IFlexibleClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:5001/SomeEntity";

        public FlexibleClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SomeEntity>> GetManyAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/GetMany");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<SomeEntity>>();
        }

        public async Task<List<SomeEntity>> GetByFilterAsync(Status? status)
        {
            string url = $"{BaseUrl}/GetByFilter";
            if (status.HasValue)
                url += $"?status={status}";
            
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<SomeEntity>>();
        }
    }

    public class CachingFlexibleClient : IFlexibleClient
    {
        private readonly IFlexibleClient _decoratedClient;
        private readonly Dictionary<string, (List<SomeEntity> data, DateTime timestamp)> _cache = new();
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

        public CachingFlexibleClient(IFlexibleClient decoratedClient)
        {
            _decoratedClient = decoratedClient;
        }

        public async Task<List<SomeEntity>> GetManyAsync()
        {
            const string key = "GetMany";
            if (_cache.ContainsKey(key) && DateTime.Now - _cache[key].timestamp < _cacheDuration)
            {
                Console.WriteLine("Returning from cache!");
                return _cache[key].data;
            }

            var result = await _decoratedClient.GetManyAsync();
            _cache[key] = (result, DateTime.Now);
            return result;
        }

        public async Task<List<SomeEntity>> GetByFilterAsync(Status? status)
        {
            string key = $"GetByFilter_{status}";
            if (_cache.ContainsKey(key) && DateTime.Now - _cache[key].timestamp < _cacheDuration)
            {
                Console.WriteLine("Returning filtered data from cache!");
                return _cache[key].data;
            }

            var result = await _decoratedClient.GetByFilterAsync(status);
            _cache[key] = (result, DateTime.Now);
            return result;
        }

        public void ClearCache() => _cache.Clear();
    }
}
