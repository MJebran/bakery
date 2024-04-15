using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class ToppingServiceTest : IToppingService
{
    List<Topping> toppings {get; set;}
    public ToppingServiceTest()
    {
        toppings = new();
    }
    public async Task AddTopping(Topping topping)
    {
        toppings.Add(topping);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Topping>> GetAllToppings()
    {
        await Task.CompletedTask;
        return toppings;
    }
}