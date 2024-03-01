using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPurchaseController : ControllerBase
    {
        ItemPurchaseService _service;

        public ItemPurchaseController(ItemPurchaseService service)
        {
            _service = service;
        }

        [HttpGet("itempurchases")]
        public async Task<IEnumerable<Itempurchase>> GetAllItemPurchasesAsync()
        {
            return await _service.GetAllItempurchase();
        }

        [HttpGet("itempurchase/{id}")]
        public async Task<Itempurchase> GetItemPurchaseByIdAsync(int id)
        {
            return await _service.GetItempurchaseById(id);
        }

        [HttpPost("add/itempurchase")]
        public async Task AddItemPurchaseAsync(Itempurchase itempurchase)
        {
            await _service.AddItempurchase(itempurchase);
        }

        [HttpDelete("delete/itempurchase/{id}")]
        public async Task DeleteItemPurchaseAsync([FromBody] int id)
        {
            await _service.DeleteItempurchase(id);
        }
    }
}
