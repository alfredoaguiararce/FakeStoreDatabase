using FakeStore.Database.Models;

namespace FakeStore.Database.RelationalModels
{
    public class FakeUserCart
    {
        public FakeUser User { get; set; }
        public List<FakeProduct>? CartProducts { get; set; }
    }
}
