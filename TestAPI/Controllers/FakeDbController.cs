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


        [HttpPost("users")]
        public IActionResult AddUser()
        {
            List<FakeUser> users = _FakeStoredDb.GetUsers();
            users.Add(new FakeUser()
            {
                UserId = 101,
                Email = "string",
                Archived = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                FirstName = "string",
                IsAdmin = false,
                LastName = "string",
                Password = "string",
                UserName = "string"
            });

            _FakeStoredDb.UpdateUsers(users);
            return Ok(_FakeStoredDb.GetUsers());
        }


        [HttpPut("users/{userId}")]
        public IActionResult UpdateUser(int userId)
        {
            List<FakeUser> users = _FakeStoredDb.GetUsers();
            FakeUser? userToUpdate = users.FirstOrDefault(u => u.UserId == userId);

            if (userToUpdate != null)
            {
                userToUpdate.UserName = "string new";
                userToUpdate.Email = "new email";
                // Update other properties as needed.

                return Ok(userToUpdate);
            }

            return NotFound(); // If the user with the given ID is not found.
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
