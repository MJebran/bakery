using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        IItemTypeService _service;
        public ItemTypeController(IItemTypeService service)
        {
            _service = service;
        }

        [HttpGet("itemtypes")]

        public async Task<IEnumerable<Itemtype>> GetAllItemTypeAsync()
        {
            return await _service.GetAllItemtypes();
        }

        [HttpPost("add/itemtype")]

        public async Task AddItemTypeAsync(Itemtype item)
        {
            await _service.AddItemtype(item);
        }

        [HttpPut("update/itemtype")]

        public async Task UpdateItemTypeAsync(Itemtype item)
        {
            await _service.UpdateItemtype(item.CategoryId);
        }

        [HttpDelete("delete")]

        public async Task DeleteItemTypeAsync(Itemtype item)
        {
            await _service.DeleteItemtype(item.CategoryId);
        }
    }
}
