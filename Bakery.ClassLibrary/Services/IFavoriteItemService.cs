using Bakery.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IFavoriteItemService
{
    public Task AddFavoriteitem(Favoriteitem size);
    public Task<IEnumerable<Favoriteitem>> GetAllFavoriteitem();
    public Task<Favoriteitem> GetFavoriteitemById(int id);
    public Task DeleteFavoriteitem(int id);
    public Task UpdateFavoriteitem(int id);
}
