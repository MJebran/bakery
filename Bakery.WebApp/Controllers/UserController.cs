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
        BakeryMapper _mapper = new BakeryMapper();
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return (await _service.GetAllUsers()).Select(u => _mapper.UserToUserDto(u));
        }

        [HttpPost("/add/user")]
        public async Task AddUserAsync([FromBody] User user)
        {
            await _service.AddUser(user);
        }

        [HttpDelete("/delete/user/{id}")]
        public async Task DeleteUserAsync(int id)
        {
            await _service.DeleteUser(id);
        }

        [HttpPut("/update/user/{id}")]
        public async Task UpdateUserAsync(int id)
        {
            await _service.UpdateUser(id);
        }
    }
}
