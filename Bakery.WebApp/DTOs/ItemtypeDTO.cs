using Bakery.WebApp.Data;

namespace Bakery.WebApp.Services;

public class ItemtypeDTO
{
    public int ItemTypeId { get; set; }
    public string? ItemName { get; set; }
    public decimal? ItemPrice { get; set; }
    public int? ItmeCalories { get; set; }
    public decimal? ItemWeight { get; set; }
    public string? ItemDescription { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int SizeId { get; set; }
}
