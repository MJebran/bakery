using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _service;
        BakeryMapper _mapper = new BakeryMapper();

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("roles")]
        public async Task<IEnumerable<RoleDTO>> GetRolesAsync() 
        {
            return (await _service.GetAllRoles()).Select(r => _mapper.RoleToRoleDto(r));
        }
    }
}
