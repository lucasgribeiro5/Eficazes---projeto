using Core.Models;

namespace Core.Services
{
    public interface ITokenService
    {
        string CriarToken(Cliente cliente);
    }
}
