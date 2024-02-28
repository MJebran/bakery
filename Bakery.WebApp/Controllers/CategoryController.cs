using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _service;
        public CategoryController(ICategoryService services)
        {
            _service = services;
        }

        [HttpGet("categories")]
        public async Task<IEnumerable<Category>> GetAllAvailableCategories()
        {
            return await _service.GetAllCategories();
        }

        [HttpPost("add/category")]
        public async Task AddCategory(Category s)
        {
            await _service.AddCategory(s);
        }
    }
}
