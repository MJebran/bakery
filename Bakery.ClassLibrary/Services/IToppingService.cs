using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IToppingService
{
    public Task AddTopping(Topping size);
    public Task<IEnumerable<Topping>> GetAllToppings();
}
