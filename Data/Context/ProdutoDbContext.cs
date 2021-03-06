﻿using Microsoft.EntityFrameworkCore;
using Model;


namespace Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Codigo);
            //modelBuilder.Entity<Produto>()
            //   .ForSqlServerIsMemoryOptimized();
        }

        public DbSet<Produto> Produtos { get; set;  }
    }
}
