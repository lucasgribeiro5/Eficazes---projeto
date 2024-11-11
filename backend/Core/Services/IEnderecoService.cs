using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IEnderecoService
    {
        public Task<Endereco> Salvar(EnderecoDTO enderecoDTO, string clienteId);
        public Task<IEnumerable<Endereco>> ObterPorId(string clienteId);
    }
}
