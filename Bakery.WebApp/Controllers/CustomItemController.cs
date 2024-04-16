using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomItemController : ControllerBase
    {
        ICustomItemService _service;
        BakeryMapper _mapper = new BakeryMapper();
        public CustomItemController(ICustomItemService service) // is for linking 
        {
            _service = service;
        }

        [HttpGet("customitems")]
        public async Task<IEnumerable<CustomItemDTO>> GetALLCustomItemsAsync()
        {
            return (await _service.GetAllCustomitem()).Select(ci => _mapper.CustomItemToCustomItemDto(ci));
        }

        [HttpGet("customitem/{id}")]
        public async Task<CustomItemDTO> GetCustomItemByIdAsync(int id)
        {
            return _mapper.CustomItemToCustomItemDto(await _service.GetCustomeItemById(id));
        }

        [HttpPost("add/customitem")]
        public async Task AddCustomItemAsync([FromBody] Customitem customitem)
        {
            await _service.AddCustomitem(customitem);
        }

        [HttpDelete("delete/customitem/{id}")]
        public async Task DeleteCustomItemAsync(int id)
        {
            await _service.DeleteCustomitem(id);
        }

        [HttpPut("update/customitem/{id}")]
        public async Task UpdateCustomItemAsync(int id)
        {
            await _service.UpdateCustomitem(id);
        }
    }
}
