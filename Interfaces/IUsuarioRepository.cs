using Entidades;

namespace Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Usuario usuario);
        Task SeguirAsync(Guid seguidorId, Guid seguidoId);
    }
}
