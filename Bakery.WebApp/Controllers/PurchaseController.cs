﻿using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        IPurchaseService _service;
        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        [HttpGet("purchases")]

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            return await _service.GetAllPurchase();
        }

        [HttpGet("purchase/{id}")]

        public async Task<Purchase> GetPurchaseAsync(int id)
        {
            return await _service.GetPurchase(id);
        }

        [HttpPost("add/purchase")]

        public async Task AddPurchaseAsycn(Purchase purchase)
        {
            await _service.AddPurchase(purchase);
        }

        [HttpDelete("delete/purchase")]
        public async Task DeletePurchaseAsync([FromBody] int id)
        {
            await _service.DeletePurchase(id);
        }

        [HttpPut("update/purchase")]
        public async Task UpdatePurchaseAsync([FromBody] int id)
        {
            await _service.UpdatePurchase(id);
        }
    }
}
