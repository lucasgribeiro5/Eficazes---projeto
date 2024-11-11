using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {

        private readonly EficazesDbContext _context;

        public EnderecoRepository(EficazesDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> Salvar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<IEnumerable<Endereco>> ObterPorId(string clienteId)
        {
            return await _context.Enderecos
                .Where(e => e.Cliente.Id == clienteId)
                .ToListAsync();
        }
    }
}
