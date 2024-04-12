using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Components.Pages;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bakery.WebApp.Services;

public class PurchaseDTO 
{
   
    public int PurchaseId { get; set; }

    public DateOnly? PurcahseDate { get; set; }

    public bool Ispayed { get; set; }

    
    public virtual  IEnumerable<ItempurchaseDTO> Itempurchases { get; set; }

}

public class ItempurchaseDTO
{
    public int ItempurchaseId { get; set; }
    public int? ItempurchaseQuantity { get; set; }
    public virtual CustomItemDTO ItempurchaseItem { get; set; } = null!;
}

public class CustomItemDTO
{
    public int CustomItemId { get; set; }
    public virtual ICollection<CustomitemtoppingDTO> Customitemtoppings { get; set; }
}



public class CustomitemtoppingDTO
{
    public int CustomItemToppingId { get; set; }

    public int? CustomItemToppingQuantity { get; set; }

    //[ForeignKey(typeof(Topping))]
    //public int ToppingId { get; set; }

    //[ManyToOne]
    //public virtual Customitem CustomItem { get; set; } = null!;

    //[ManyToOne]
    //public virtual Topping Topping { get; set; } = null!;
}


[Mapper]
public partial class BakeryMapper
{
    public partial PurchaseDTO PurchaseToPurchaseDto(Purchase purchase);
}








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

    public async Task<Purchase> GetPurchaseAsync(int id)
    {
        return await _service.GetPurchase(id);
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

    [HttpPut("update/purchase/{id}")]
    public async Task UpdatePurchaseAsync(int id)
    {
        await _service.UpdatePurchase(id);
    }
}
