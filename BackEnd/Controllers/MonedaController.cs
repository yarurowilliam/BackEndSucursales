using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaService _monedaService;
        public MonedaController(IMonedaService monedaService)
        {
            _monedaService = monedaService;
        }

        [HttpPost]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Moneda moneda)
        {
            try
            {
                await _monedaService.SavedMonedaAsync(moneda);
                return Ok(new { message = "La moneda se registro correctamente.." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListMonedas")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListSucursalAsync()
        {
            try
            {
                var listMonedas = await _monedaService.GetListMonedasAsync();
                return Ok(listMonedas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idMoneda}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Moneda> Get(int idMoneda)
        {
            try
            {
                var moneda = await _monedaService.GetMonedaAsync(idMoneda);
                return moneda;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
