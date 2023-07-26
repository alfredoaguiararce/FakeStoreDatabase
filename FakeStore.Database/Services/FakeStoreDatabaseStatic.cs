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

        public void UpdateUsers(List<FakeUser> Users) => fakeUsers = Users;

        public List<FakeProduct> GetProducts()
        {
            if (fakeProducts is null)
            {
                fakeProducts = new List<FakeProduct>();
                fakeProducts = mFatabaseGenerator.GetProducts();
            }
            return fakeProducts;
        }

        public void UpdateProducts(List<FakeProduct> Products) => fakeProducts = Products;

        public List<FakeCategory> GetCategories()
        {
            if (fakeCategories is null)
            {
                fakeCategories = new List<FakeCategory>();
                fakeCategories = mFatabaseGenerator.GetCategories();
            }
            return fakeCategories;
        }

        public void UpdateCategories(List<FakeCategory> Categories) => fakeCategories = Categories;

    }

    /* The `IFakeStoreDatabase` interface defines a contract for a class that provides access to a fake
    store database. It declares three methods: */
    public interface IFakeStoreDatabase
    {
        /// <summary>
        /// The function returns a list of fake users, generating them if they don't already exist.
        /// </summary>
        /// <returns>
        /// The method is returning a List of FakeUser objects.
        /// </returns>
        List<FakeUser> GetUsers();
        /// <summary>
        /// The function returns a list of fake products, retrieving them from a database generator if
        /// they haven't been retrieved before.
        /// </summary>
        /// <returns>
        /// The method is returning a List of FakeProduct objects.
        /// </returns>
        List<FakeProduct> GetProducts();
        /// <summary>
        /// The function returns a list of fake categories, generating them if they don't already exist.
        /// </summary>
        /// <returns>
        /// The method is returning a List of FakeCategory objects.
        /// </returns>
        List<FakeCategory> GetCategories();
        /// <summary>
        /// The function updates the list of fake users with a new list of users.
        /// </summary>
        /// <param name="Users">The parameter "Users" is a list of objects of type "FakeUser".</param>
        void UpdateUsers(List<FakeUser> Users);
        /// <summary>
        /// The function updates the list of fake products with a new list of fake products.
        /// </summary>
        /// <param name="Products">The parameter "Products" is a list of objects of type
        /// "FakeProduct".</param>
        void UpdateProducts(List<FakeProduct> Products);
        /// <summary>
        /// The function updates the list of fake categories with the provided list of categories.
        /// </summary>
        /// <param name="Categories">The parameter "Categories" is a list of objects of type
        /// "FakeCategory".</param>
        void UpdateCategories(List<FakeCategory> Categories);
    }
}
