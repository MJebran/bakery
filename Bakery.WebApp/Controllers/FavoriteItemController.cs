using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteItemController : ControllerBase
    {
        IFavoriteItemService _service;
        public FavoriteItemController(IFavoriteItemService service)
        {
            _service = service;
        }
        [HttpGet("favoritieitems")]
        public async Task<IEnumerable<Favoriteitem>> GetAllFavoriteItems()
        {
            return await _service.GetAllFavoriteitem();
        }

        [HttpGet("favoriteitem/{id}")]

        public async Task<Favoriteitem> GetFavoriteItem(int id)
        {
            return await _service.GetFavoriteitemById(id);
        }
        [HttpPost("add/favoriteitem")]

        public async Task AddFAvoriteItemAsycn([FromBody] Favoriteitem favorite)
        {
            await _service.AddFavoriteitem(favorite);
        }

        [HttpDelete("delete/favoriteItem/{id}")]
        public async Task DeletePurchaseAsync(int id)
        {
            await _service.DeleteFavoriteitem(id);
        }

        [HttpPut("update/favoriteItem/{id}")]
        public async Task UpdatePurchaseAsync(int id)
        {
            await _service.UpdateFavoriteitem(id);
        }
    }
}
