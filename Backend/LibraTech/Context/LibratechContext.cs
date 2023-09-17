using LibraTech.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraTech.Context
{
    public class LibratechContext : DbContext
    {
        
        public LibratechContext(DbContextOptions<LibratechContext> options) : base(options)
        {
            
        }
        public DbSet<Livro> Livros { get; set; }
    }
}
