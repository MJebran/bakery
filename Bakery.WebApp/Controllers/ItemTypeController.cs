﻿using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Bakery.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        IItemTypeService _service;
        BakeryMapper _mapper = new BakeryMapper();

        public ItemTypeController(IItemTypeService service)
        {
            _service = service;
        }

        [HttpGet("itemtypes")]

        public async Task<IEnumerable<ItemtypeDTO>> GetAllItemTypeAsync()
        {
            return (await _service.GetAllItemtypes()).Select(it => _mapper.ItemTypeToItemTypeDto(it));
        }

        [HttpPost("add/itemtype")]

        public async Task AddItemTypeAsync([FromBody] Itemtype item)
        {
            await _service.AddItemtype(item);
        }

        [HttpPut("update/itemtype/{id}")]

        public async Task UpdateItemTypeAsync(int id)
        {
            await _service.UpdateItemtype(id);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteItemTypeAsync(int id)
        {
            await _service.DeleteItemtype(id);
        }
    }
}
