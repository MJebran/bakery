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
        public ToppingController(IToppingService service)
        {
            _service = service;
        }

        [HttpGet("toppings")]
        public async Task<IEnumerable<Topping>> GetAllAvailableToppings()
        {
            return await _service.GetAllToppings();
        }

        [HttpPost("add/topping")]
        public async Task AddTopping(Topping s)
        {
            await _service.AddTopping(s);
        }
    }
}
