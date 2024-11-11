using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EficazesDbContext _context;

        public AuthRepository(EficazesDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> ObterCliente(string email, string password)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => (c.Email == email || c.Apelido == email) && c.Senha == password);
        }
    }
}
