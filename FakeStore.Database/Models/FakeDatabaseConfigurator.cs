namespace FakeStore.Database.Models
{
    public class FakeDatabaseConfigurator
    {
        public UsersConfigurator UsersConfiguration { get; set; }
        public ProductsConfigurator ProductsConfiguration { get; set; }
        public CategoriesConfigurator CategoriesConfiguration { get; set; }
    }

    public class UsersConfigurator
    {
        public int MaxDefaultUsers { get; set; }
        public float NullProbability { get; set;}
    }

    public class ProductsConfigurator
    {
        public int MaxProducts { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public float NullProbability { get; set; }
    }
    public class CategoriesConfigurator
    {
        public int MaxCategories { get; set; }
        public float NullProbability { get; set; }
    }
}
