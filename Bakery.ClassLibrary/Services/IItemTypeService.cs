using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IItemTypeService
{
    public Task AddItemtype(Itemtype size);
    public Task<IEnumerable<Itemtype>> GetAllItemtypes();
    public Task DeleteItemtype(int id);
    public Task UpdateItemtype(int id);
}
