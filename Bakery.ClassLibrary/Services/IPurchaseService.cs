using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IPurchaseService
{
    public Task AddPurchase(Purchase size);
    public Task<IEnumerable<Purchase>> GetAllPurchase();
    public Task UpdatePurchase(Purchase purchase);
    public Task<Purchase> GetPurchase(int id);
    public Task DeletePurchase(int id);
}
