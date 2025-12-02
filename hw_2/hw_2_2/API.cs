namespace hw2_2
{
    using System;
    using System.Collections.Generic;

    public class SomeEntityApiController
    {
        private List<SomeEntity> _entities = new();
        private int _nextId = 1;

        public SomeEntity Create(SomeEntity entity)
        {
            entity.Id = _nextId++;
            _entities.Add(entity);
            Console.WriteLine($"Создана запись: {entity.Name} (ID: {entity.Id})");
            return entity;
        }

        public SomeEntity Update(SomeEntity entity)
        {
            var existing = _entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existing == null)
            {
                Console.WriteLine($"Обновление: Запись ID {entity.Id} не найдена");
                return null;
            }

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.Status = entity.Status;
            Console.WriteLine($"Обновление: Обновлена запись ID {entity.Id}");
            return existing;
        }

        public SomeEntity GetOne(int id)
        {
            var entity = _entities.Find(e => e.Id == id);
            if (entity == null)
                Console.WriteLine($"Запись с ID {id} не найдена");
            else
                Console.WriteLine($"Найдена запись: {entity.Name}");
            return entity;
        }

        public List<SomeEntity> GetMany()
        {
            Console.WriteLine($"Возвращено {_entities.Count} записей");
            return _entities;
        }

        public bool Delete(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                Console.WriteLine($"Удаление: Запись ID {id} не найдена");
                return false;
            }

            _entities.Remove(entity);
            Console.WriteLine($"Удаление: Удалена запись ID {id}");
            return true;
        }

        public int DeleteMany(List<int> ids)
        {
            int deletedCount = 0;
            foreach (var id in ids)
            {
                if (Delete(id))
                    deletedCount++;
            }
            Console.WriteLine($"Удалено: Удалено {deletedCount} из {ids.Count} записей");
            return deletedCount;
        }

        public List<SomeEntity> GetByFilter(string status)
        {
            var filtered = _entities.FindAll(e => e.Status == status);
            Console.WriteLine($"Найдено {filtered.Count} записей со статусом '{status}'");
            return filtered;
        }

        public void Print(int id)
        {
            var entity = GetOne(id);
            if (entity == null) 
                Console.WriteLine($"Печать: Запись ID {id} не найдена");
            else 
                Console.WriteLine($"Печать: Создан документ для записи ID {id}");
        }

        public void PrintMany(List<int> ids)
        {
            var documents = new List<string>();
            foreach (var id in ids)
            {
                var doc = $"Создан документ для записи ID {id}";
                documents.Add(doc);
            }
            Console.WriteLine($"Печать: Создано {documents.Count} документов");
        }

        public SomeEntity SetStatus(int id, string status)
        {
            var entity = GetOne(id);
            if (entity == null)
                return null;

            var oldStatus = entity.Status;
            entity.Status = status;
            Console.WriteLine($"Статус: Запись ID {id} изменена с '{oldStatus}' на '{status}'");
            return entity;
        }

        public SomeEntity Deactivate(int id)
        {
            Console.WriteLine($"Деактивация: Деактивация записи ID {id}");
            return SetStatus(id, "Inactive");
        }

        public SomeEntity Activate(int id)
        {
            Console.WriteLine($"Активация: Активация записи ID {id}");
            return SetStatus(id, "Active");
        }

        public void Clear()
        {
            _entities.Clear();
            _nextId = 1;
            Console.WriteLine("База данных очищена");
        }
    }

}