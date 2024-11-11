using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IClienteService _clienteService;
        private readonly IEnderecoRepository _enderecoRepository;


        public EnderecoService(IEnderecoRepository enderecoRepositor, IClienteService clienteService)
        {
            _enderecoRepository = enderecoRepositor;
            _clienteService = clienteService;
        }

        public async Task<Endereco> Salvar(EnderecoDTO enderecoDTO, string clienteId)
        {
            Cliente cliente = await _clienteService.ObterPorId(clienteId);
            if (cliente == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            Endereco endereco = new Endereco(enderecoDTO);
            endereco.Cliente = cliente;

            return await _enderecoRepository.Salvar(endereco);
        }

        public async Task<IEnumerable<Endereco>> ObterPorId(string clienteId)
        {
            return await _enderecoRepository.ObterPorId(clienteId);
        }

    }
}
