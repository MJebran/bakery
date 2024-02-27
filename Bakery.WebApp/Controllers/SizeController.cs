using Bakery.ClassLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bakery.WebApp.Data;
using System.Net.Sockets;

namespace Bakery.WebApp.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        ISizeService _service;
        public SizeController(ISizeService services)
        {
            _service = services;
        }

        [HttpGet("sizes")]
        public async Task<IEnumerable<Size>> GetAllAvailableSizes()
        {
            return await _service.GetAllSizes();
        }

        [HttpPost("add/size")]
        public async Task AddSize(Size s)
        {
            await _service.AddSize(s);
        }
    }
}
