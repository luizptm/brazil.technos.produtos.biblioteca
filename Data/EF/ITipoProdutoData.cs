using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ITipoProdutoData
    {
        public TipoProduto Get(string codigo);

        public List<TipoProduto> Find(TipoProduto TipoProduto);

        public Boolean Salvar(TipoProduto TipoProduto);

        Boolean Excluir(string codigo);

        public Boolean Excluir(TipoProduto TipoProduto);
    }
}
