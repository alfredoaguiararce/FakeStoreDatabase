using Bogus;
using FakeStore.Database.Models;

namespace FakeStore.Database.Generators
{
    internal class DatabaseGenerator: IFakeStoreDatabase
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

    }

    public interface IFakeStoreDatabase
    {
        List<FakeUser> GetUsers();
    }
}
