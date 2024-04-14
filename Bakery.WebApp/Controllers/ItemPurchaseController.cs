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
        BakeryMapper _mapper = new BakeryMapper();

        public ItemPurchaseController(IItemPurchaseService service)
        {
            _service = service;
        }

        [HttpGet("itempurchases")]
        public async Task<IEnumerable<ItempurchaseDTO>> GetAllItemPurchasesAsync()
        {
            return (await _service.GetAllItempurchase()).Select(ip => _mapper.ItemPurchaseToItemPurchaseDto(ip));
        }

        [HttpGet("itempurchase/{id}")]
        public async Task<ItempurchaseDTO> GetItemPurchaseByIdAsync(int id)
        {
            return _mapper.ItemPurchaseToItemPurchaseDto(await _service.GetItempurchaseById(id));
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
