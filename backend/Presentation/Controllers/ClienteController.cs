using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IAuthService _authService;

        public ClienteController(IClienteService ClienteService, IAuthService AuthService)
        {
            _authService = AuthService;
            _clienteService = ClienteService;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = await _clienteService.Salvar(clienteDTO);

            return CreatedAtAction(nameof(PostCliente), new { id = cliente.Id }, cliente);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Cliente>> PutCliente(ClienteDTO clienteDTO)
        {
            string id = _authService.GetAuthenticatedClienteId(User);
            Cliente cliente = await _clienteService.Atualizar(id, clienteDTO);

            return AcceptedAtAction(nameof(PutCliente), new { id = cliente.Id }, cliente);
        }

        [HttpGet]
        public async Task<ActionResult<Cliente>> ObterClienteLogado()
        {
            string clientId = _authService.GetAuthenticatedClienteId(User);
            return await _clienteService.ObterPorId(clientId);
        }

        [Authorize]
        [HttpPost("foto")]
        public async Task<ActionResult<String>> PostFoto(IFormFile Foto)
        {
            if (Foto == null || Foto.Length == 0)
            {
                return BadRequest("No image found");
            }

            using var memoryStream = new MemoryStream();
            await Foto.CopyToAsync(memoryStream);

            Imagem imagem = new Imagem
            {
                NomeDoArquivo = Foto.FileName,
                Conteudo = memoryStream.ToArray(),
                TipoDeConteudo = Foto.ContentType,
                Extensao = Path.GetExtension(Foto.FileName),
            };

            string clienteId = _authService.GetAuthenticatedClienteId(User);
            string imageUrl = await _clienteService.GuardarImagem(imagem, clienteId);

            return CreatedAtAction(nameof(PostFoto), imageUrl);
        }
    }

}
