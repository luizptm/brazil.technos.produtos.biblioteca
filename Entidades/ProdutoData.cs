using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProdutoData : IProdutoData
    {
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
