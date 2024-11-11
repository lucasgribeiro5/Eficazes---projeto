using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IClienteService
    {
        public Task<Cliente> ObterPorId(string id);
        public Task<Cliente> Salvar(ClienteDTO clienteDTO);
        public Task<Cliente> Atualizar(string id, ClienteDTO clienteDTO);
        public Task<string> GuardarImagem(Imagem imagem, string id);
    }
}
