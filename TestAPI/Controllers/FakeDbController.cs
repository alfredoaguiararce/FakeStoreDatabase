using FakeStore.Database.Generators;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_FakeStoredDb.GetUsers());
        }
    }
}
