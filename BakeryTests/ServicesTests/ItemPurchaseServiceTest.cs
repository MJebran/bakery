using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class ItemPurchaseServiceTest : IItemPurchaseService
{
    List<Itempurchase> itempurchases { get; set; }
    public ItemPurchaseServiceTest()
    {
        itempurchases = new();
    }
    public async Task AddItempurchase(Itempurchase size)
    {
        itempurchases.Add(size);
        await Task.CompletedTask;
    }

    public async Task DeleteItempurchase(int id)
    {
        var itemToRemove = itempurchases.Where(ip => ip.ItempurchaseId == id).FirstOrDefault();
        itempurchases.Remove(itemToRemove ?? throw new Exception("no item to remove"));
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Itempurchase>> GetAllItempurchase()
    {
        await Task.CompletedTask;
        return itempurchases;
    }

    public async Task<Itempurchase> GetItempurchaseById(int id)
    {
        var itemToReturn = itempurchases.Where(ip => ip.ItempurchaseId == id).FirstOrDefault();
        await Task.CompletedTask;
        return itemToReturn ?? throw new Exception("no item to return found");
    }

    public Task UpdateItempurchase(int id)
    {
        throw new NotImplementedException();
    }
}