
using FakeStore.Database.Generators;
using FakeStore.Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FakeStore.Database
{
    public static class FakeStoreDatabase
    {
        public static void UseFakeStoreDatabase(this IServiceCollection Services, FakeDatabaseConfigurator configurator)
        {
            Services.AddScoped<IFakeStoreDatabase>(ServiceNameCollection => new DatabaseGenerator(configurator));
        }
    }
}