using Microsoft.EntityFrameworkCore;
using Model;


namespace Data
{
    public class TipoProdutoDbContext : DbContext
    {
        public TipoProdutoDbContext(DbContextOptions options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProduto>()
                .HasKey(p => p.Id);
        }

        public DbSet<TipoProduto> TipoProdutos { get; set; }
    }
}
