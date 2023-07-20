namespace FakeStore.Database.Models
{
    public class FakeCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Archived { get; set; }
        public int UserCreatorId { get; set; }

    }
}
