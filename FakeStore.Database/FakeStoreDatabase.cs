using FakeStore.Database.Models;
using FakeStore.Database.Services.Generators;
using FakeStore.Database.Statics;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FakeStore.Database
{
    public static class FakeStoreDatabase
    {
        /// <summary>
        /// The function extends the IServiceCollection in C# to register and configure a fake store
        /// database.
        /// </summary>
        /// <param name="IServiceCollection">The `IServiceCollection` is a collection of service
        /// descriptors that are used to configure the dependency injection container in ASP.NET Core.
        /// It is used to register and resolve services within the application.</param>
        /// <param name="FakeDatabaseConfigurator">The FakeDatabaseConfigurator is a class that is
        /// responsible for configuring the fake store database. It may contain properties or methods
        /// that allow you to specify the number of records, the types of data to generate, or any other
        /// configuration options for the fake store database.</param>
        /// <returns>
        /// The method is returning an instance of `FakeStoreDatabaseStatic` which implements the
        /// `IFakeStoreDatabase` interface.
        /// </returns>
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