using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IImagemService _imageService;

        public ClienteService(IClienteRepository clienteRepository, IImagemService imageService)
        {
            _clienteRepository = clienteRepository;
            _imageService = imageService;
        }

        public async Task<Cliente> Atualizar(string id, ClienteDTO clienteDTO)
        {
            Cliente? cliente = await _clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            cliente.Nome = clienteDTO.Nome;
            cliente.Email = clienteDTO.Email;

            await _clienteRepository.Atualizar(cliente);

            return cliente;
        }

        public async Task<string> GuardarImagem(Imagem imagem, string id)
        {
            string url = await _imageService.GuardarImagem(imagem, "clientes", id);

            Cliente cliente = await _clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            cliente.Foto = url;

            await _clienteRepository.Atualizar(cliente);

            return url;
        }

        public async Task<Cliente> ObterPorId(string id)
        {
            return await _clienteRepository.ObterPorId(id);
        }


        public async Task<Cliente> Salvar(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente(clienteDTO);

            await _clienteRepository.Adicionar(cliente);

            return cliente;
        }
    }
}
