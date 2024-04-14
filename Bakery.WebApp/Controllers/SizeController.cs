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
        BakeryMapper _mapper = new BakeryMapper();
        public SizeController(ISizeService services)
        {
            _service = services;
        }

        [HttpGet("sizes")]
        public async Task<IEnumerable<SizeDTO>> GetAllAvailableSizes()
        {
            return (await _service.GetAllSizes()).Select(s => _mapper.SizeToSizeDto(s));
        }

        [HttpPost("add/size")]
        public async Task AddSize([FromBody] Size s)
        {
            await _service.AddSize(s);
        }
    }
}
