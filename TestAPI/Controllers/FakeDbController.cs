using FakeStore.Database.Models;
using FakeStore.Database.Statics;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeDbController: ControllerBase
    {
        private readonly IFakeStoreDatabase _FakeStoredDb;

        public FakeDbController(IFakeStoreDatabase fakeStoredDb)
        {
            _FakeStoredDb = fakeStoredDb;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(_FakeStoredDb.GetUsers());
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(_FakeStoredDb.GetProducts());
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(_FakeStoredDb.GetCategories());
        }

        [HttpGet("relations")]
        public IActionResult CategoriesProductsRelation()
        {
            List<FakeCategory> categories = _FakeStoredDb.GetCategories();
            List<FakeProduct> products = _FakeStoredDb.GetProducts();

            // Realizar la unión basada en el CategoryId
            var joinedData = categories
                .Join(products,
                    category => category.CategoryId,
                    product => product.CategoryId,
                    (category, product) => new
                    {
                        Category = category,
                        Product = product
                    })
                .ToList();

            // Ejemplo: Obtener los nombres de productos para un CategoryId específico
            int categoryIdToFilter = 1;
            var productsWithCategoryId = joinedData
                .Where(data => data.Category.CategoryId == categoryIdToFilter)
                .Select(data => data.Product.Name)
                .ToList();

            return Ok(productsWithCategoryId);
        }
    }
}
