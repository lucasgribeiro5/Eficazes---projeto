using Core.Models;
using Core.Repositories;
using Core.Services;
using System.Security.Claims;

namespace Presentation.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<string> Login(string email, string senha)
        {
            Cliente cliente = await ObterCliente(email, senha);
            string token = _tokenService.CriarToken(cliente);

            return token;
        }

        private async Task<Cliente> ObterCliente(string email, string senha)
        {
            Cliente? cliente = await _authRepository.ObterCliente(email, senha);
            if (cliente == null)
            {
                throw new Exception("Usuário e/ou senha inválidos");
            }

            return cliente;
        }

        public string GetAuthenticatedClienteId(ClaimsPrincipal Cliente)
        {
            string? clienteId = Cliente.Claims.First(c => c.Type == "id")?.Value;
            if (clienteId == null)
            {
                throw new Exception("User not found on token JWT");
            }

            return clienteId;
        }
    }
}
