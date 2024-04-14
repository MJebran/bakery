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
        BakeryMapper _mapper = new BakeryMapper();

        public CategoryController(ICategoryService services)
        {
            _service = services;
        }

        [HttpGet("categories")]
        public async Task<IEnumerable<CategoryDTO>> GetAllAvailableCategories()
        {
            return (await _service.GetAllCategories()).Select(c => _mapper.CategoryToCategoryDto(c));
        }

        [HttpPost("add/category")]
        public async Task AddCategory([FromBody] Category s)
        {
            await _service.AddCategory(s);
        }
    }
}
