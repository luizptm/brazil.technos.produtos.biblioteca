using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Data
{
    public class ProdutoData : IProdutoData
    {
        protected readonly ProdutoDbContext db;

        public ProdutoData()
        {
            db = new ProdutoDbContext();
        }

        public Produto Get(string codigo)
        {
            var data = this.db.Produtos.Find(codigo);
            return data;
        }

        public List<Produto> GetAll()
        {
            var data = new List<Produto>();
            data = this.db.Produtos.ToList();
            return data;
        }

        public PagedResultDto<Produto> GetPagedData(int maxCountReg, int skip)
        {
            var list = new List<Produto>();
            var totalRegistros = 0;
            var result = this.GetAll();
            if (result != null)
            {
                totalRegistros = result.Count;
                var query = result.AsQueryable();
                list = query.Page(skip, maxCountReg).ToList();
            }

            return new PagedResultDto<Produto>(list, totalRegistros);
        }

        public List<Produto> Find(Produto produto)
        {
            var data = new List<Produto>();
            data = this.db.Produtos.Where(x => x.Codigo == produto.Codigo
            || x.Descricao == produto.Descricao
            || x.Marca == produto.Marca
            || x.Preco == produto.Preco 
            || x.DataCadastro == produto.DataCadastro 
            || x.DataLancamento == produto.DataLancamento).ToList();
            return data;
        }

        public Boolean Salvar(Produto produto)
        {
            if (produto.Codigo == null)
            {
                produto.DataCadastro = new DateTime();
                this.db.Produtos.Add(produto);
            }
            else
            {
                db.Entry(produto).State = EntityState.Modified;
            }
            db.SaveChanges();
            return true;
        }

        public Boolean Excluir(string codigo)
        {
            Produto produto = this.Get(codigo);
            this.db.Produtos.Remove(produto);
            db.SaveChanges();
            return true;
        }

        public Boolean Excluir(Produto produto)
        {
            this.db.Produtos.Remove(produto);
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
