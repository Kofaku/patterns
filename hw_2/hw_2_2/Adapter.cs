namespace hw2_2
{
    public class SomeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public interface ICrudClient<T>
    {
        T Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }

    public class SomeEntityApiAdapter : ICrudClient<SomeEntity>
    {
        private readonly SomeEntityApiController _apiController;

        public SomeEntityApiAdapter(SomeEntityApiController apiController)
        {
            _apiController = apiController;
        }

        public SomeEntity Create(SomeEntity item)
        {
            return _apiController.Create(item);
        }

        public SomeEntity Read(int id)
        {
            return _apiController.GetOne(id);
        }

        public void Update(SomeEntity item)
        {
            _apiController.Update(item);
        }

        public void Delete(int id)
        {
            _apiController.Delete(id);
        }
    }
}
