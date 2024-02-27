using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IItemPurchaseService
{
    public Task AddItempurchase(Itempurchase size);
    public Task<IEnumerable<Itempurchase>> GetAllItempurchase();
    //public Task DeleteItempurchase(int id);
    public Task GetItempurchaseById(int id);
    public Task UpdateItempurchase(int id);
}
