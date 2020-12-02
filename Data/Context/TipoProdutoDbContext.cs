using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace Data
{
    public class TipoProdutoDbContext : DbContext
    {
        public TipoProdutoDbContext()
        : base("name=GrupoTechnos")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<TipoProduto> TipoProdutos { get; set; }
    }
}
