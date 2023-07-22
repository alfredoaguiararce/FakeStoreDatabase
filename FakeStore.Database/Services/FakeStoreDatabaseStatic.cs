using FakeStore.Database.Models;
using FakeStore.Database.Services.Generators;

namespace FakeStore.Database.Statics
{
    internal class FakeStoreDatabaseStatic : IFakeStoreDatabase
    {
        private static List<FakeUser>? fakeUsers;
        private static List<FakeProduct>? fakeProducts;
        private static List<FakeCategory>? fakeCategories;
        private readonly IFakeStoreDatabaseGenerator mFatabaseGenerator;

        public FakeStoreDatabaseStatic(IFakeStoreDatabaseGenerator mFatabaseGenerator)
        {
            this.mFatabaseGenerator = mFatabaseGenerator;
        }

        public List<FakeUser> GetUsers()
        {
            if(fakeUsers is null)
            {
                fakeUsers = new List<FakeUser>();
                fakeUsers = mFatabaseGenerator.GetUsers();
            }
            return fakeUsers;
        }
        public List<FakeProduct> GetProducts()
        {
            if (fakeProducts is null)
            {
                fakeProducts = new List<FakeProduct>();
                fakeProducts = mFatabaseGenerator.GetProducts();
            }
            return fakeProducts;
        }

        public List<FakeCategory> GetCategories()
        {
            if (fakeCategories is null)
            {
                fakeCategories = new List<FakeCategory>();
                fakeCategories = mFatabaseGenerator.GetCategories();
            }
            return fakeCategories;
        }


    }

    public interface IFakeStoreDatabase
    {
        List<FakeUser> GetUsers();
        List<FakeProduct> GetProducts();
        List<FakeCategory> GetCategories();
    }
}
