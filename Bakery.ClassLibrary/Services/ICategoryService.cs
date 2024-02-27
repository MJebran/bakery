using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface ICategoryService
{
    public Task AddCategory(Topping size);
    public Task<IEnumerable<Topping>> GetAllCategories();
}
