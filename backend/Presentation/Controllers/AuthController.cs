using Application.Services;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<string>> Login(SignInClienteDTO loginCliente)
        {
            string token = await _authService.Login(loginCliente.Email, loginCliente.Senha);
            return CreatedAtAction(nameof(Login), token);
        }
    }
}
