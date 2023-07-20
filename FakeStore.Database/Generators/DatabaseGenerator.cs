using Bogus;
using FakeStore.Database.Models;

namespace FakeStore.Database.Generators
{
    internal class DatabaseGenerator : IFakeStoreDatabase
    {
        private readonly FakeDatabaseConfigurator _Configurator;
        public DatabaseGenerator(FakeDatabaseConfigurator configurator)
        {
            _Configurator = configurator;
        }

        public List<FakeUser> GetUsers()
        {
            int MaxDefaultUsers = _Configurator.UsersConfiguration.MaxDefaultUsers;
            float ProbabilityOfNull = _Configurator.UsersConfiguration.NullProbability;
            int counter = 1;

            var faker = new Faker<FakeUser>()
            .RuleFor(u => u.UserId, f => counter++)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.CreatedAt, f => f.Date.Past())
                .RuleFor(u => u.Archived, (f, u) => f.Random.Bool(ProbabilityOfNull) ? null : f.Date.Recent(30, DateTime.Now)) // 30% de probabilidad de que sea null
                .RuleFor(u => u.IsAdmin, f => f.Random.Bool());

            List<FakeUser> fakeUsers = faker.Generate(MaxDefaultUsers);

            return fakeUsers;
        }

        public List<FakeProduct> GetProducts()
        {
            int MaxCategories = _Configurator.CategoriesConfiguration.MaxCategories;

            int MaxProducts = _Configurator.ProductsConfiguration.MaxProducts;
            int MinPrice = _Configurator.ProductsConfiguration.MinPrice;
            int MaxPrice = _Configurator.ProductsConfiguration.MaxPrice;
            float ProbabilityOfNull = _Configurator.ProductsConfiguration.NullProbability;

            int MaxDefaultUsers = _Configurator.UsersConfiguration.MaxDefaultUsers;
            int counter = 1;

            var faker = new Faker<FakeProduct>()
                .RuleFor(u => u.ProductId, f => counter++)
                .RuleFor(p => p.UserCreatorId, f => f.Random.Number(1, MaxDefaultUsers))
                .RuleFor(p => p.CategoryId, f => f.Random.Number(1, MaxCategories))
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => f.Random.Float(MinPrice, MaxPrice))
                .RuleFor(p => p.CreatedAt, f => f.Date.Past())
                .RuleFor(u => u.Archived, (f, u) => f.Random.Bool(ProbabilityOfNull) ? null : f.Date.Recent(30, DateTime.Now)); // 30% de probabilidad de que sea null

            List<FakeProduct> fakeProducts = faker.Generate(MaxDefaultUsers);
            return fakeProducts;
        }

        public List<FakeCategory> GetCategories()
        {
            int MaxCategories = _Configurator.CategoriesConfiguration.MaxCategories;
            float ProbabilityOfNull = _Configurator.CategoriesConfiguration.NullProbability;

            int MaxDefaultUsers = _Configurator.UsersConfiguration.MaxDefaultUsers;
            int counter = 0;

            var faker = new Faker<FakeCategory>()
                .RuleFor(u => u.CategoryId, f => counter++) // Incremento después de asignar el valor.
                .RuleFor(c => c.Name, f =>
                {
                    // Lista de nombres de categorías ya utilizados.
                    List<string> usedNames = new List<string>();

                    // Obtenemos la lista de nombres de categorías ficticias.
                    var categories = f.Commerce.Categories(MaxCategories);

                    // Iteramos hasta encontrar un nombre que no se haya utilizado previamente.
                    string categoryName;
                    do
                    {
                        categoryName = f.PickRandom(categories);
                    } while (usedNames.Contains(categoryName));

                    // Agregamos el nombre a la lista de nombres utilizados.
                    usedNames.Add(categoryName);

                    return categoryName;
                })
                .RuleFor(c => c.CreatedAt, f => f.Date.Past())
                .RuleFor(u => u.Archived, (f, u) => f.Random.Bool(ProbabilityOfNull) ? null : f.Date.Recent(30, DateTime.Now))
                .RuleFor(c => c.UserCreatorId, f => f.Random.Number(1, MaxDefaultUsers));

            List<FakeCategory> FakeCategories = faker.Generate(MaxCategories);
            return FakeCategories;
        }



    }

    public interface IFakeStoreDatabase
    {
        List<FakeCategory> GetCategories();
        List<FakeProduct> GetProducts();
        List<FakeUser> GetUsers();
    }
}
