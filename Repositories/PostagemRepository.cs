using Microsoft.EntityFrameworkCore;
using Entidades;
using Interfaces;
using Context;
using System.Linq;

namespace Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly AppDbContext _context;

        public PostagemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Postagem>> ObterTodasAsync()
        {
            return await _context.Postagens
                                 .Include(p => p.Autor)
                                 .Include(p => p.Curtidas)
                                 .ToListAsync();
        }

        public async Task<Postagem?> ObterPorIdAsync(Guid id)
        {
            return await _context.Postagens
                                 .Include(p => p.Autor)
                                 .Include(p => p.Curtidas)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task CurtirAsync(Guid postagemId, Guid usuarioId)
        {
            var postagem = await _context.Postagens
                                         .Include(p => p.Curtidas)
                                         .FirstOrDefaultAsync(p => p.Id == postagemId);

            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (postagem != null && usuario != null && !postagem.Curtidas.Contains(usuario))
            {
                postagem.Curtidas.Add(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ComentarAsync(Guid postagemId, string comentario)
        {
            var postagem = await _context.Postagens.FindAsync(postagemId);
            if (postagem != null)
            {
                postagem.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
