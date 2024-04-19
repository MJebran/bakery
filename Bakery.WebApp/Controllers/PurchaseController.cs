using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Components.Pages;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Services;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : ControllerBase
{
    IPurchaseService _service;
    BakeryMapper _mapper = new BakeryMapper();
    public PurchaseController(IPurchaseService service)
    {
        _service = service;
    }

    [HttpGet("purchases")]

    public async Task<IEnumerable<PurchaseDTO>> GetAllPurchases()
    {

        return (await _service.GetAllPurchase()).Select(p => _mapper.PurchaseToPurchaseDto(p));  // used the _mapper in here
    }

    [HttpGet("purchase/{id}")]

    public async Task<PurchaseDTO> GetPurchaseAsync(int id)
    {
        return _mapper.PurchaseToPurchaseDto(await _service.GetPurchase(id));
    }

    [HttpPost("add/purchase")]

    public async Task AddPurchaseAsycn([FromBody] Purchase purchase)
    {
        await _service.AddPurchase(purchase);
    }

    [HttpDelete("delete/purchase/{id}")]
    public async Task DeletePurchaseAsync(int id)
    {
        await _service.DeletePurchase(id);
    }

    [HttpPut("update/purchase")]
    public async Task UpdatePurchaseAsync([FromBody] Purchase purchase)
    {
        await _service.UpdatePurchase(purchase);
    }
}
