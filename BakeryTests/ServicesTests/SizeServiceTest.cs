using Bakery.ClassLibrary.Services;

namespace BakeryTests.ServiceTests;

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
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Bakery.WebApp.Data.Size>> GetAllSizes()
    {
        await Task.CompletedTask;
        return sizes;
    }
}