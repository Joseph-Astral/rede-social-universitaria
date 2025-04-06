using Entidades;

namespace Interfaces
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> ObterTodasAsync();
        Task<Postagem?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Postagem postagem);
        Task CurtirAsync(Guid postagemId, Guid usuarioId);
        Task ComentarAsync(Guid postagemId, string comentario);
    }
}
