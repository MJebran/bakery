using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Bakery.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomeItemToppingController : ControllerBase
    {
        ICustomeItemToppingService _service;
        BakeryMapper _mapper = new BakeryMapper();
        public CustomeItemToppingController(ICustomeItemToppingService service)
        {
            _service = service;
        }
        [HttpGet("custometoppingitem")]
        public async Task<IEnumerable<CustomitemtoppingDTO>> GetAllAvailableToppings()
        {
            return (await _service.GetAllCustomeItemTopping()).Select(cit => _mapper.CustomItemToppingToCustomItemToppingDto(cit));
        }

        [HttpPost("add/custometoppingItem")]
        public async Task AddTopping([FromBody] Customitemtopping s)
        {
            await _service.AddCustomeItemTopping(s);
        }
        [HttpDelete("delete/{id}")]
        public async Task DeleteCustomeItemToppingAsync(int id)
        {
            await _service.DeleteCustomeItemTopping(id);
        }

    }
}
