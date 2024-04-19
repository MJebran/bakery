using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace BakeryTests.ServiceTests;

public class PurchaseServiceTest : IPurchaseService
{
    List<Purchase> purchases { get; set; }
    public PurchaseServiceTest()
    {
        purchases = new();
    }
    public async Task AddPurchase(Purchase size)
    {
        purchases.Add(size);
        await Task.CompletedTask;
    }

    public async Task DeletePurchase(int id)
    {
        var itemToRemove = purchases.Where(p => p.PurchaseId == id).FirstOrDefault();
        purchases.Remove(itemToRemove ?? throw new Exception("No purchase found"));
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Purchase>> GetAllPurchase()
    {
        await Task.CompletedTask;
        return purchases;
    }

    public async Task<Purchase> GetPurchase(int id)
    {
        var itemToReturn = purchases.Where(p => p.PurchaseId == id).FirstOrDefault();
        await Task.CompletedTask;
        return itemToReturn ?? throw new Exception("no purchase found");
    }

    public Task UpdatePurchase(Purchase purchase)
    {
        throw new NotImplementedException();
    }
}