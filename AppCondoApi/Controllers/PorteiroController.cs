using AppCondo.Application.DTO;
using AppCondo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCondoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PorteiroController : Controller
    {
        private readonly IPorteiroService _porteiroService;

        public PorteiroController(IPorteiroService porteiroService)
        {
            _porteiroService = porteiroService;
        }

        [HttpGet("/buscar-porteiro{id}")]
        public async Task<IActionResult> BuscarPorteiro([FromQuery] int id)
        {
            return View();
        }

        [HttpPost("/cadastrar-porteiro")]
        public async Task<IActionResult> CadastrarPorteiro([FromBody] PorteiroDTO porteiro)
        {
            if (porteiro is null)
                return BadRequest("Dados inválidos");

            var cadastro = await _porteiroService.CadastrarPorteiro(porteiro);

            if(cadastro.Success is false)
            {
                return BadRequest(cadastro.Message);
            }

            return Ok(cadastro);
        }

    }
}
