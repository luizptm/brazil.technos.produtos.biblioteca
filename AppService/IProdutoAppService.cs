using Model;
using System;
using System.Collections.Generic;

namespace AppService
{
    public interface IProdutoAppService
    {
        Produto Get(Int32 codigo);

        List<Produto> GetAll();

        List<Produto> Find(Produto produto);

        Boolean Salvar(Produto produto);

        Boolean Excluir(Int32 codigo);

        Boolean Excluir(Produto produto);
    }
}
