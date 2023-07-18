namespace FakeStore.Database.Models
{
    public class FakeDatabaseConfigurator
    {
        public UsersConfigurator UsersConfiguration { get; set; }
        public int MaxDefaultProducts { get; set; }
        public int MaxDefaultCategories { get; set; }
    }

    public class UsersConfigurator
    {
        public int MaxDefaultUsers { get; set; }
        public float NullProbability { get; set;}
    }
}
