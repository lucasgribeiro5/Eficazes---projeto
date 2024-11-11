using Core.Models;

namespace Core.Repositories
{
    public interface IEnderecoRepository
    {
        public Task<Endereco> Salvar(Endereco endereco);

        public Task<IEnumerable<Endereco>> ObterPorId(string clienteId);
    }
}
