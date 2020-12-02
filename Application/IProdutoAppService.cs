using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppService
{
    public interface IProdutoAppService
    {
        Produto Get(string codigo);

        List<Produto> Find(Produto produto);

        Boolean Salvar(Produto produto);

        Boolean Excluir(Produto produto);
    }
}
