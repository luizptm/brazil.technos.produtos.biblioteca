using Data.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Data
{
    public class TipoProdutoData : ITipoProdutoData
    {
        private readonly TipoProdutoDbContext db;

        public TipoProdutoData()
        {
            db = new TipoProdutoDbContext();
        }

        TipoProduto IRepository<TipoProduto>.Get(int id)
        {
            var data = this.db.TipoProdutos.Find(id);
            return data;
        }

        List<TipoProduto> IRepository<TipoProduto>.GetAll()
        {
            var data = new List<TipoProduto>();
            data = this.db.TipoProdutos.ToList();
            return data;
        }

        PagedResultDto<TipoProduto> IRepository<TipoProduto>.GetPagedData(int maxCountReg, int skip)
        {
            List<TipoProduto> list = new List<TipoProduto>();
            int totalRegistros = 0;
            List<TipoProduto> result = this.GetAll();
            if (result != null)
            {
                totalRegistros = result.Count;
                var query = result.AsQueryable();
                list = query.Page(skip, maxCountReg).ToList();
            }

            return new PagedResultDto<TipoProduto>(list, totalRegistros);
        }

        private TipoProduto Get(int id)
        {
            var data = this.db.TipoProdutos.Find(id);
            return data;
        }

        private List<TipoProduto> GetAll()
        {
            var data = new List<TipoProduto>();
            data = this.db.TipoProdutos.ToList();
            return data;
        }

        List<TipoProduto> IRepository<TipoProduto>.Find(TipoProduto tipoProduto)
        {
            var data = new List<TipoProduto>();
            data = this.db.TipoProdutos.Where(x => x.Id == tipoProduto.Id
            || x.Nome == tipoProduto.Nome).ToList();
            return data;
        }

        Boolean IRepository<TipoProduto>.Salvar(TipoProduto tipoProduto)
        {
            if (tipoProduto.Id == null)
            {
                this.db.TipoProdutos.Add(tipoProduto);
            }
            else
            {
                db.Entry(tipoProduto).State = EntityState.Modified;
            }
            db.SaveChanges();
            return true;
        }

        Boolean IRepository<TipoProduto>.Excluir(int id)
        {
            TipoProduto produto = this.Get(id);
            this.db.TipoProdutos.Remove(produto);
            db.SaveChanges();
            return true;
        }

        Boolean IRepository<TipoProduto>.Excluir(TipoProduto produto)
        {
            this.db.TipoProdutos.Remove(produto);
            db.SaveChanges();
            return true;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}
