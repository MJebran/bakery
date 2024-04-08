using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using BakeryTests;
using System.Net.Http.Json;

class SizeServiceTest : ISizeService
{
    List<Bakery.WebApp.Data.Size> sizes {get; set;}
    public SizeServiceTest()
    {
        sizes = new();
    }
    public async Task AddSize(Bakery.WebApp.Data.Size size)
    {
        sizes.Add(size);
    }

    public async Task<IEnumerable<Bakery.WebApp.Data.Size>> GetAllSizes()
    {
        return sizes;
    }
}