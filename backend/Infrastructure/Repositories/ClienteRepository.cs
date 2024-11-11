using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EficazesDbContext _context;

        public ClienteRepository(EficazesDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            var clienteDb = await _context.Clientes.FindAsync(cliente.Id);
            if (clienteDb == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            clienteDb.Nome = cliente.Nome;
            clienteDb.Email = cliente.Email;

            await _context.SaveChangesAsync();
            return cliente;
        }


        public async Task<Cliente?> ObterPorId(string id)
        {
            return await _context.Clientes.FindAsync(id);
        }
    }
}
