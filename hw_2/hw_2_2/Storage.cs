
namespace hw_2_2
{
    public static class Storage
    {
        public static List<SomeEntity> Entities { get; set; } = new List<SomeEntity>
        {
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 1", Description = "Description 1", Status = Status.Active },
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 2", Description = "Description 2", Status = Status.Inactive },
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 3", Description = "Description 3", Status = Status.Pending },
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 4", Description = "Description 4", Status = Status.Active },
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 5", Description = "Description 5", Status = Status.Inactive }
        };
    }
}
