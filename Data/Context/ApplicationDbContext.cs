using Microsoft.EntityFrameworkCore;
using Model;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Codigo);
            modelBuilder.Entity<TipoProduto>()
                .HasKey(p => p.Id);
        }
    }
}
