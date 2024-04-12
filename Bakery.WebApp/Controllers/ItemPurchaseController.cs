using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Bakery.ClassLibrary.Services;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPurchaseController : ControllerBase
    {
        IItemPurchaseService _service;

        public ItemPurchaseController(IItemPurchaseService service)
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
        public async Task AddItemPurchaseAsync([FromBody] Itempurchase itempurchase)
        {
            await _service.AddItempurchase(itempurchase);
        }

        [HttpDelete("delete/itempurchase/{id}")]
        public async Task DeleteItemPurchaseAsync(int id)
        {
            await _service.DeleteItempurchase(id);
        }

        [HttpPut("update/itempurchase/{id}")]
        public async Task UpdateItemPurchaseAsync(int id)
        {
            await _service.UpdateItempurchase(id);
        }
    }
}
