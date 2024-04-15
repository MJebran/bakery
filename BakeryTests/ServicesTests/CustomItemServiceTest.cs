using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class CustomItemServiceTest : ICustomItemService
{
    public List<Customitem>? customitems {get; set;}
    public CustomItemServiceTest()
    {
        customitems = new();
    }
    public async Task AddCustomitem(Customitem customitem)
    {
        customitems!.Add(customitem);
        await Task.CompletedTask;
    }

    public async Task DeleteCustomitem(int id)
    {
        var itemToDelete = customitems!.Where(ci => ci.CustomItemId == id).FirstOrDefault();
        customitems!.Remove(itemToDelete ?? throw new Exception("no item passed in to delete"));
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Customitem>> GetAllCustomitem()
    {
        await Task.CompletedTask;
        return customitems!;
    }

    public async Task<Customitem> GetCustomeItemById(int id)
    {
        var itemToReturn = customitems!.Where(ci => ci.CustomItemId == id).FirstOrDefault();
        await Task.CompletedTask;
        return itemToReturn ?? throw new Exception("item to retun is null");
    }

    public async Task UpdateCustomitem(int id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}