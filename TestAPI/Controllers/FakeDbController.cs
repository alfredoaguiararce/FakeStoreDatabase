using FakeStore.Database.Services.Generators;
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
    }
}
