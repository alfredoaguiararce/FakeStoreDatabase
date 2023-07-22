using FakeStore.Database.Models;
using FakeStore.Database.Services.Generators;

namespace FakeStore.Database.Statics
{
    public class StaticCollectionsService : IFakeStoreDatabase
    {
        private static List<FakeUser> fakeUsers= new List<FakeUser>();
        private static List<FakeProduct> fakeProducts= new List<FakeProduct>();
        private static List<FakeCategory> fakeCategories= new List<FakeCategory>();
        private readonly IFakeStoreDatabaseGenerator mFatabaseGenerator;

        public StaticCollectionsService(IFakeStoreDatabaseGenerator mFatabaseGenerator)
        {
            this.mFatabaseGenerator = mFatabaseGenerator;
            fakeUsers = mFatabaseGenerator.GetUsers();
            fakeProducts = mFatabaseGenerator.GetProducts();
            fakeCategories = mFatabaseGenerator.GetCategories();
        }

        public List<FakeUser> GetUsers() => fakeUsers;
        public List<FakeProduct> GetProducts() => fakeProducts;
        public List<FakeCategory> GetCategories() => fakeCategories;


    }

    public interface IFakeStoreDatabase
    {
        List<FakeUser> GetUsers();
        List<FakeProduct> GetProducts();
        List<FakeCategory> GetCategories();
    }
}
