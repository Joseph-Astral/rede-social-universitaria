using Entidades;

namespace Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> ObterTodosAsync();
        Task<Evento?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Evento evento);
        Task InscreverAsync(Guid eventoId, Guid usuarioId);
    }
}
