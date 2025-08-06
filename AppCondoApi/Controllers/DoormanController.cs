using AppCondo.Application.DTO;
using AppCondo.Application.Interfaces;
using AppCondo.Domain.Doorman;
using Microsoft.AspNetCore.Mvc;

namespace AppCondoApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DoormanController : ControllerBase
    {
        private readonly IDoormanService _doormanService;
        private ILogger<DoormanController> _logger;

        public DoormanController(IDoormanService doormanService, ILogger<DoormanController> logger)
        {
            _doormanService = doormanService;
            _logger = logger;
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [HttpGet("/dorman/id")]
        public async Task<IActionResult> GetDoorman([FromQuery] int id)
        {
            var result = await _doormanService.GetById(id);

            if (result is null)
                return NoContent();

            return Ok(result);
        }

        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode:StatusCodes.Status400BadRequest)]
        [HttpPost("/register")]
        public async Task<IActionResult> RegisterDoorman([FromBody] DoormanDTO porteiro)
        {
            try
            {
                if (porteiro is not DoormanDTO)
                    return BadRequest("Dados inválidos");

                if (ModelState.IsValid is false)
                    return BadRequest(ModelState.ToString());

                var doorman = await _doormanService.RegisterDoorman(porteiro);

                if (doorman is not Doorman)
                    return BadRequest("Não foi possível cadastrar o porteiro");

                return Ok(doorman);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível realizar o cadastro - LOG :" + ex.Message);
                return BadRequest("Não foi possível realizar o cadastro");
            }
        }
        [HttpPut("/active")]
        public async Task<IActionResult> ActiveRegister([FromQuery] int id, [FromQuery] string registrationId)
        {
            try
            {
                var active = await _doormanService.ActiveDoormanRegister(id, registrationId);

                if (active)
                    return Ok();

                return BadRequest("Erro ao ativar usuário");
            }
        }

    }
}
