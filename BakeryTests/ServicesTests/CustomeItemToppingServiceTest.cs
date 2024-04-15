using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class CustomeItemToppingServiceTest : ICustomeItemToppingService
{
    public List<Customitemtopping> customItemToppings {get; set;} 

    public CustomeItemToppingServiceTest()
    {
        customItemToppings = new();
    }
    public async Task AddCustomeItemTopping(Customitemtopping custome)
    {
        customItemToppings.Add(custome);
        await Task.CompletedTask;
    }

    public async Task DeleteCustomeItemTopping(int id)
    {
        var itemToRemove = customItemToppings.Where(cit => cit.CustomItemToppingId == id).FirstOrDefault();
        customItemToppings.Remove(itemToRemove);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Customitemtopping>> GetAllCustomeItemTopping()
    {
        await Task.CompletedTask;
        return customItemToppings;  
    }

    public async Task<Customitemtopping> GetCustomeItemToppingById(int id)
    {
        var itemToReturn = customItemToppings.Where(cit => cit.CustomItemToppingId == id).FirstOrDefault();
        await Task.CompletedTask;
        return itemToReturn;
    }
}