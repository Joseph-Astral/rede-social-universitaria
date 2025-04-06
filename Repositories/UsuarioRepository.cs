using Microsoft.EntityFrameworkCore;
using Entidades;
using Interfaces;
using Context;

namespace Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync() =>
            await _context.Usuarios.Include(u => u.Seguidores).ToListAsync();

        public async Task<Usuario?> ObterPorIdAsync(Guid id) =>
            await _context.Usuarios.Include(u => u.Seguidores)
                                   .FirstOrDefaultAsync(u => u.Id == id);

        public async Task AdicionarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task SeguirAsync(Guid seguidorId, Guid seguidoId)
        {
            var seguidor = await _context.Usuarios.FindAsync(seguidorId);
            var seguido = await _context.Usuarios.FindAsync(seguidoId);

            if (seguidor != null && seguido != null && !seguido.Seguidores.Contains(seguidor))
            {
                seguido.Seguidores.Add(seguidor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
