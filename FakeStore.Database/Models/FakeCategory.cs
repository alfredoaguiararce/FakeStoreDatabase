namespace FakeStore.Database.Models
{
    public class FakeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? IsArchived { get; set; }
        public int UserCreatorId { get; set; }

    }
}
