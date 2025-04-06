namespace Entidades
{
    public class Evento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }

        public bool RequerInscricao { get; set; }
        public List<Usuario> Inscritos { get; set; } = new();
    }
}
