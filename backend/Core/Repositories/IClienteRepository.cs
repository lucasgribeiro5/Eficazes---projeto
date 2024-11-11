using Core.Models;

namespace Core.Repositories
{
    public interface IClienteRepository
    {
        public Task<Cliente> Adicionar(Cliente cliente);

        public Task<Cliente> Atualizar(Cliente cliente);

        public Task<Cliente?> ObterPorId(string id);
    }
}
