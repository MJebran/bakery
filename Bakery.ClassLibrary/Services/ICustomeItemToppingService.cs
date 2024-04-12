using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface ICustomeItemToppingService
{
    public Task AddCustomeItemTopping(Customitemtopping custome);
    public Task<IEnumerable<Customitemtopping>> GetAllCustomeItemTopping();
    public Task<Customitemtopping> GetCustomeItemToppingById(int id);
    public Task DeleteCustomeItemTopping(int id);
}
