
using LibraTech.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraTech.Context
{
    public class LibratechContext : DbContext
    {
        public LibratechContext(DbContextOptions<LibratechContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Autor> Autores { get; set; } = null!;
        public DbSet<Editora> Editoras { get; set; } = null!;
        public DbSet<Edicao> Edicoes { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Emprestimo> Emprestimos { get; set; } = null!;
        public DbSet<Localizacao> Localizacoes { get; set; } = null!;
        public DbSet<Multa> Multas { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Exemplar> Exemplares { get; set; } = null!;
        public DbSet<Estante> Estantes { get; set; } = null!;
        public DbSet<Prateleira> Prateleiras { get; set; } = null!;
        public DbSet<Renovacao> Renovacoes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exemplar>()
                .HasOne(e => e.Prateleira)
                .WithMany(l => l.Exemplares);

            modelBuilder.Entity<Livro>()
               .HasMany(l => l.Edicoes)
                .WithOne(e => e.Livro)
                .HasForeignKey(e => e.LivroId);

            modelBuilder.Entity<Edicao>()
                .HasMany(e => e.Exemplares)
                .WithOne(ex => ex.Edicao)
                .HasForeignKey(ex => ex.EdicaoId);


            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Livros);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Exemplar)
                .WithMany(e => e.Reservas)
                .HasForeignKey(r => r.ExemplarId);


            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Exemplar)
                .WithMany(ex => ex.Emprestimos);

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.Id);
        }
    }
}
