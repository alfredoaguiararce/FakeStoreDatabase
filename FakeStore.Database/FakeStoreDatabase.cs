using FakeStore.Database.Models;
using FakeStore.Database.Services.Generators;
using FakeStore.Database.Statics;
using Microsoft.Extensions.DependencyInjection;

namespace FakeStore.Database
{
    public static class FakeStoreDatabase
    {
        public static void UseFakeStoreDatabase(this IServiceCollection Services, FakeDatabaseConfigurator configurator)
        {
            Services.AddScoped<IFakeStoreDatabaseGenerator>(ServiceNameCollection => new DatabaseGenerator(configurator));

        }
    }
}