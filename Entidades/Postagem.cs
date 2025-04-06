namespace Entidades
{
    public class Postagem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Usuario Autor { get; set; } = null!;
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.Now;

        public List<Usuario> Curtidas { get; set; } = new();
        public List<string> Comentarios { get; set; } = new();
    }
}
