using FakeStore.Database.Models;
using FakeStore.Database.Services.Generators;
using FakeStore.Database.Statics;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FakeStore.Database
{
    public static class FakeStoreDatabase
    {
        public static void UseFakeStoreDatabase(this IServiceCollection Services, FakeDatabaseConfigurator configurator)
        {
            Services.AddScoped<IFakeStoreDatabaseGenerator>(service => new FakeStoreDatabaseGenerator(configurator));
            Services.AddScoped<IFakeStoreDatabase>(service =>
            {
                IFakeStoreDatabaseGenerator generator = service.GetRequiredService<IFakeStoreDatabaseGenerator>();
                return new FakeStoreDatabaseStatic(generator);
            });
        }
    }
}