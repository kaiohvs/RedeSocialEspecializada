using Microsoft.EntityFrameworkCore;
using RedeSocialEspecializada.Models;

namespace RedeSocialEspecializada.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Postagem> postagems { get; set; }
        public DbSet<GrupoUsuario> GruposUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupoUsuario>()
                .HasKey(gu => new { gu.GrupoId, gu.UsuarioId });
        }
    }
}
