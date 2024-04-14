using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        IToppingService _service;
        BakeryMapper _mapper = new BakeryMapper();
        public ToppingController(IToppingService service)
        {
            _service = service;
        }

        [HttpGet("toppings")]
        public async Task<IEnumerable<ToppingDTO>> GetAllAvailableToppings()
        {
            return (await _service.GetAllToppings()).Select(t => _mapper.ToppingToToppingDto(t));
        }

        [HttpPost("add/topping")]
        public async Task AddTopping([FromBody] Topping s)
        {
            await _service.AddTopping(s);
        }
    }
}
