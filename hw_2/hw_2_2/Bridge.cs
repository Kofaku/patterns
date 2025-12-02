namespace hw2_2
{
    public class SomeImageEntity : SomeEntity
    {
        public string ImageUrl { get; set; }
    }

    public interface IImageApi
    {
        SomeImageEntity GetImage(int id);
        void SetImage(SomeImageEntity entity);
        List<SomeImageEntity> GetEntitiesByFilter(string filter);
    }

    public class ImageApiBridge : IImageApi
    {
        private readonly SomeEntityApiController _apiController;

        public ImageApiBridge(SomeEntityApiController apiController)
        {
            _apiController = apiController;
        }

        public SomeImageEntity GetImage(int id)
        {
            var entity = _apiController.GetOne(id);
            if (entity == null)
            {
                Console.WriteLine($"Получить картинку: Запись с ID {id} не найдена");
                return null;
            }
            return new SomeImageEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                ImageUrl = "URL картинки"
            };
        }

        public void SetImage(SomeImageEntity entity)
        {
            _apiController.Update(entity);
        }

        public List<SomeImageEntity> GetEntitiesByFilter(string filter)
        {
            var entities = _apiController.GetByFilter(filter);
            return entities.Select(e => new SomeImageEntity
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Status = e.Status,
                ImageUrl = "URL картинки"
            }).ToList();
        }
    }
}