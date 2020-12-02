using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class ProdutoController : IProdutoController
    {
        public ProdutoController(IProdutoData data)
        {
        }

        public Produto Get(string codigo)
        {
            return null;
        }

        public List<Produto> Find(Produto produto)
        {
            return null;
        }

        public Boolean Salvar(Produto produto)
        {
            return true;
        }

        public Boolean Excluir(Produto produto)
        {
            return true;
        }
    }
}
