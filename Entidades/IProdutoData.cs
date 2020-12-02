using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IProdutoData
    {
        public Produto Get(string codigo);

        public List<Produto> Find(Produto produto);

        public Boolean Salvar(Produto produto);

        public Boolean Excluir(Produto produto);
    }
}
