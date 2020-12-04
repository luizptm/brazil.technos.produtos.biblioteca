using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext db;

        public ProdutoRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        Produto IRepository<Produto>.Get(int codigo)
        {
            var data = this.db.Produtos.Find(codigo);
            return data;
        }

        List<Produto> IRepository<Produto>.GetAll()
        {
            var data = new List<Produto>();
            data = this.db.Produtos.ToList();
            return data;
        }

        PagedResultDto<Produto> IRepository<Produto>.GetPagedData(int maxCountReg, int skip)
        {
            List<Produto> list = new List<Produto>();
            int totalRegistros = 0;
            List<Produto> result = this.GetAll();
            if (result != null)
            {
                totalRegistros = result.Count;
                var query = result.AsQueryable();
                list = query.Page(skip, maxCountReg).ToList();
            }

            return new PagedResultDto<Produto>(list, totalRegistros);
        }

        private Produto Get(int id)
        {
            var data = this.db.Produtos.Find(id);
            return data;
        }

        private List<Produto> GetAll()
        {
            var data = new List<Produto>();
            data = this.db.Produtos.ToList();
            return data;
        }

        List<Produto> IRepository<Produto>.Find(Produto produto)
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

        Boolean IRepository<Produto>.Salvar(Produto produto)
        {
            if (produto.Codigo == null)
            {
                produto.DataCadastro = new DateTime();
                this.db.Produtos.Add(produto);
            }
            else
            {
                db.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified ;
            }
            db.SaveChanges();
            return true;
        }

        Boolean IRepository<Produto>.Excluir(int codigo)
        {
            Produto produto = this.Get(codigo);
            if (produto != null)
            {
                this.db.Produtos.Remove(produto);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        Boolean IRepository<Produto>.Excluir(Produto produto)
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
