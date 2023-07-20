namespace FakeStore.Database.Models
{
    public class FakeProduct
    {
        public int ProductId { get; set; }
        public int UserCreatorId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Archived { get; set; }

    }
}
