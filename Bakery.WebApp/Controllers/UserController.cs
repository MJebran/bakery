using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("users")]

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _service.GetAllUsers();
        }

        [HttpPost("/add/user")]
        public async Task AddUserAsync(User user)
        {
            await _service.AddUser(user);
        }

        [HttpDelete("/delete/user")]
        public async Task DeleteUserAsync(User user)
        {
            await _service.DeleteUser(user.UserId);
        }

        [HttpPut("/update/user")]
        public async Task UpdateUserAsync(User user)
        {
            await _service.UpdateUser(user.UserId);
        }


    }
}
