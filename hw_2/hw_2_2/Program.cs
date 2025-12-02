namespace hw2_2
{
    class Program
    {
        static void Main()
        {
            var controller = new SomeEntityApiController();
            controller.Clear();

            var entity1 = controller.Create(new SomeEntity
            {
                Name = "Запись 1",
                Description = "Первая запись",
                Status = "Active"
            });

            var entity2 = controller.Create(new SomeEntity
            {
                Name = "Запись 2",
                Description = "Вторая запись",
                Status = "Inactive"
            });

            var entity3 = controller.Create(new SomeEntity
            {
                Name = "Запись 3",
                Description = "Третья запись",
                Status = "Active"
            });

            var found = controller.GetOne(1);
            if (found != null)
                Console.WriteLine($"Найдена: {found}");

            var all = controller.GetMany();
            Console.WriteLine($"Всего записей: {all.Count}");

            var active = controller.GetByFilter("Active");
            Console.WriteLine($"Активных записей: {active.Count}");

            var inactive = controller.GetByFilter("Inactive");
            Console.WriteLine($"Неактивных записей: {inactive.Count}");

            controller.Update(new SomeEntity
            {
                Id = 1,
                Name = "Обновленная Запись 1",
                Description = "Новое описание",
                Status = "Waiting"
            });

            controller.SetStatus(2, "Archived");

            controller.Deactivate(1);
            controller.Activate(2);


            controller.Print(1);
            controller.PrintMany(new List<int> { 1, 2, 3 });

            controller.Delete(3);
            controller.DeleteMany(new List<int> { 4, 5, 6 });

            var adapter = new SomeEntityApiAdapter(controller);
            var newEntity = adapter.Create(new SomeEntity { Name = "Через адаптер", Status = "Active" });
            adapter.Read(newEntity.Id);
            adapter.Update(new SomeEntity { Id = newEntity.Id, Name = "Обновлено через адаптер", Status = "Inactive" });
            adapter.Delete(newEntity.Id);

            var flexible = new FlexibleClient(controller);
            var cachingClient = new CachingFlexibleClient(flexible);

            cachingClient.GetMany();

            cachingClient.GetMany();

            cachingClient.GetByFilter("Active");

            cachingClient.GetByFilter("Active");

            var imageApi = new ImageApiBridge(controller);

            controller.Create(new SomeEntity { Name = "Запись с картинкой", Status = "Active" });

            var imageEntity = imageApi.GetImage(4);
            if (imageEntity != null)
                Console.WriteLine($"Получена сущность с изображением: {imageEntity}");

            var filteredImages = imageApi.GetEntitiesByFilter("Active");
            Console.WriteLine($"Найдено изображений: {filteredImages.Count}");
        }
    }
}