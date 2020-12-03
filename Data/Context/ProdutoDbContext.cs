using Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext()
        : base("name=GrupoTechnos")
            {
            }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Produto> Produtos { get; set;  }
    }
}
