using AppCondo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCondoApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(string login, string password)
        {

            var token = await loginService.Login(login, password);

            if (String.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(new { token });

        }
    }
}
