namespace Bakery.WebApp.Services;

public class ToppingDTO
{
    public int ToppingId { get; set; }
    public string? ToppingName { get; set; }
    public decimal? ToppingPrice { get; set; }
    public decimal? ToppingWeight { get; set; }
    public int? ToppingCalories { get; set; }
    public string? ToppingUnit { get; set; }
}
