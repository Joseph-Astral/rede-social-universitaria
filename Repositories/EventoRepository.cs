using Microsoft.EntityFrameworkCore;
using Entidades;
using Interfaces;
using Context;

namespace Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> ObterTodosAsync() =>
            await _context.Eventos.Include(e => e.Inscritos).ToListAsync();

        public async Task<Evento?> ObterPorIdAsync(Guid id) =>
            await _context.Eventos.Include(e => e.Inscritos).FirstOrDefaultAsync(e => e.Id == id);

        public async Task AdicionarAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
        }

        public async Task InscreverAsync(Guid eventoId, Guid usuarioId)
        {
            var evento = await _context.Eventos.Include(e => e.Inscritos).FirstOrDefaultAsync(e => e.Id == eventoId);
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (evento != null && usuario != null && evento.RequerInscricao && !evento.Inscritos.Contains(usuario))
            {
                evento.Inscritos.Add(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
