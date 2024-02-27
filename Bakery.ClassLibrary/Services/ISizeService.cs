using Bakery.WebApp.Data;

namespace Bakery.ClassLibrary.Services;

public interface ISizeService
{
    public Task AddSize(Size size);
    public Task<IEnumerable<Size>> GetAllSizes();
}
