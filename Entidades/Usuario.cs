namespace Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;

        public List<Usuario> Seguidores { get; set; } = new();
    }
}
