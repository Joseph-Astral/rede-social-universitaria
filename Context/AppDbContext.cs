using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Postagem> Postagens => Set<Postagem>();
        public DbSet<Evento> Eventos => Set<Evento>();
    }
}
