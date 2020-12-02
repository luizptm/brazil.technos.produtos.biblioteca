using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class TipoProdutoData : ITipoProdutoData
    {
        public TipoProduto Get(string codigo)
        {
            return null;
        }

        public List<TipoProduto> Find(TipoProduto TipoProduto)
        {
            return null;
        }

        public Boolean Salvar(TipoProduto TipoProduto)
        {
            return true;
        }

        public Boolean Excluir(TipoProduto TipoProduto)
        {
            return true;
        }
    }
}
