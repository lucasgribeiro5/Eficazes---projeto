using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IAuthService _authService;

        public EnderecoController(IEnderecoService addressService, IAuthService authService)
        {
            _enderecoService = addressService;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(EnderecoDTO enderecoDTO)
        {
            string userId = _authService.GetAuthenticatedClienteId(User);

            Endereco endereco = await _enderecoService.Salvar(enderecoDTO, userId);

            return CreatedAtAction(nameof(PostEndereco), new { id = endereco.Id }, endereco);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecos()
        {
            string userId = _authService.GetAuthenticatedClienteId(User);
            IEnumerable<Endereco> enderecos = await _enderecoService.ObterPorId(userId);

            return CreatedAtAction(nameof(GetEnderecos), enderecos);
        }
    }

}
