using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using BakeryTests;
using System.Net.Http.Json;

class ItemTypeServiceTest : IItemTypeService
{
    List<Itemtype> itemtypes {get; set;}
    public ItemTypeServiceTest()
    {
        itemtypes = new();
    }
    public async Task AddItemtype(Itemtype size)
    {
        itemtypes.Add(size);
    }

    public async Task DeleteItemtype(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Itemtype>> GetAllItemtypes()
    {
        return itemtypes;
    }

    public async Task UpdateItemtype(int id)
    {
        throw new NotImplementedException();
    }
}