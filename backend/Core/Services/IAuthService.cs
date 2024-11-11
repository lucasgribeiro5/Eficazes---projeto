using Core.Models;
using System.Security.Claims;

namespace Core.Services
{
    public interface IAuthService
    {
        public Task<string> Login(string email, string senha);
        public string GetAuthenticatedClienteId(ClaimsPrincipal Cliente);
    }
}
