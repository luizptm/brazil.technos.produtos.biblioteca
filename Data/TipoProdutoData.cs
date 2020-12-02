﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class TipoProdutoData : ITipoProdutoData
    {
        protected readonly TipoProdutoDbContext db;

        public TipoProdutoData()
        {
            db = new TipoProdutoDbContext();
        }

        public TipoProduto Get(string codigo)
        {
            var data = this.db.TipoProdutos.Find(codigo);
            return data;
        }

        public List<TipoProduto> GetAll()
        {
            var data = new List<TipoProduto>();
            data = this.db.TipoProdutos.ToList();
            return data;
        }

        public List<TipoProduto> Find(TipoProduto tipoProduto)
        {
            var data = new List<TipoProduto>();
            data = this.db.TipoProdutos.Where(x => x.Id == tipoProduto.Id
            || x.Nome == tipoProduto.Nome).ToList();
            return data;
        }

        public Boolean Salvar(TipoProduto produto)
        {
            this.db.TipoProdutos.Add(produto);
            db.SaveChanges();
            return true;
        }

        public Boolean Excluir(string codigo)
        {
            TipoProduto produto = this.Get(codigo);
            this.db.TipoProdutos.Remove(produto);
            db.SaveChanges();
            return true;
        }

        public Boolean Excluir(TipoProduto produto)
        {
            this.db.TipoProdutos.Remove(produto);
            db.SaveChanges();
            return true;
        }
    }
}
