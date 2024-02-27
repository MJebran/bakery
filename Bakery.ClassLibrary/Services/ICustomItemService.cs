using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface ICustomItemService
{
    public Task AddCustomitem(Customitem size);
    public Task<IEnumerable<Customitem>> GetAllCustomitem();
    public Task DeleteCustomitem(int id);
    public Task UpdateCustomitem(int id);
}

