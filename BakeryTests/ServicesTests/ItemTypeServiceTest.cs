using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using BakeryTests;
using System.Net.Http.Json;

namespace BakeryTests.ServiceTests;
public class ItemTypeServiceTest : IItemTypeService
{
    List<Itemtype> itemtypes { get; set; }
    public ItemTypeServiceTest()
    {
        itemtypes = new();
    }
    public async Task AddItemtype(Itemtype size)
    {
        itemtypes.Add(size);
        await Task.CompletedTask;
    }

    public async Task AddItemtypes(List<Itemtype> items)
    {
        foreach (var item in items)
        {
            itemtypes.Add(item);
        }
        await Task.CompletedTask;
    }

    public async Task DeleteItemtype(int id)
    {
        var itemToRemove = itemtypes.Where(it => it.ItemTypeId == id).FirstOrDefault();
        itemtypes.Remove(itemToRemove ?? throw new Exception("No itemtype to remove"));
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Itemtype>> GetAllItemtypes()
    {
        await Task.CompletedTask;
        return itemtypes;
    }

    public async Task UpdateItemtype(int id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}