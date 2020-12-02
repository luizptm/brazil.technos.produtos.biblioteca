using Data;
using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class ProdutoController : IProdutoController
    {
        protected readonly IProdutoData data;

        public ProdutoController(IProdutoData data)
        {
            this.data = data;
        }

        public Produto Get(string codigo)
        {
            var result = this.data.Get(codigo);
            return result;
        }

        public List<Produto> GetAll()
        {
            var result = this.data.GetAll();
            return result;
        }

        public PagedResultDto<Produto> GetPagedData(int maxCountReg, int skip)
        {
            var result = this.data.GetPagedData(maxCountReg, skip);
            return result;
        }

        public List<Produto> Find(Produto produto)
        {
            var result = this.data.Find(produto);
            return result;
        }

        public Boolean Salvar(Produto produto)
        {
            var result = this.data.Salvar(produto);
            return result;
        }

        public Boolean Excluir(string codigo)
        {
            var result = this.data.Excluir(codigo);
            return result;
        }

        public Boolean Excluir(Produto produto)
        {
            var result = this.data.Excluir(produto);
            return result;
        }
    }
}
