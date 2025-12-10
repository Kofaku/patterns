namespace hw_2_2
{
    public class SomeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Active,
        Inactive,
        Pending
    }

    public class SomeImageEntity : SomeEntity
    {
        public string ImageUrl { get; set; }
    }
}