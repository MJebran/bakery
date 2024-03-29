using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomeItemToppingController : ControllerBase
    {
        ICustomeItemToppingService _service;

        public CustomeItemToppingController(ICustomeItemToppingService service)
        {
            _service = service;
        }
        [HttpGet("custometoppingitem")]
        public async Task<IEnumerable<Customitemtopping>> GetAllAvailableToppings()
        {
            return await _service.GetAllCustomeItemTopping();
        }

        [HttpPost("add/custometoppingItem")]
        public async Task AddTopping(Customitemtopping s)
        {
            await _service.AddCustomeItemTopping(s);
        }
        [HttpDelete("delete")]

        public async Task DeleteCustomeItemToppingAsync([FromBody] Itemtype item)
        {
            await _service.DeleteCustomeItemTopping(item.CategoryId);
        }

    }
}
