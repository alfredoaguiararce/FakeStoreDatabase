using FakeStore.Database.Models;

namespace FakeStore.Database.RelationalModels
{
    internal class FakeUserCart
    {
        public FakeUser User { get; set; }
        public List<FakeProduct>? CartProducts { get; set; }
    }
}
