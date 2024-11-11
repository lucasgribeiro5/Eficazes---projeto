using Core.Models;

namespace Core.Repositories
{
    public interface IAuthRepository
    {
        public Task<Cliente?> ObterCliente(string email, string password);
    }
}
