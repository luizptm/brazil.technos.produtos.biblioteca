using Data;
using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public interface IProdutoController
    {
        Produto Get(string codigo);

        List<Produto> GetAll();

        PagedResultDto<Produto> GetPagedData(int maxCountReg, int skip);

        List<Produto> Find(Produto produto);

        Boolean Salvar(Produto produto);

        Boolean Excluir(string codigo);

        Boolean Excluir(Produto produto);
    }
}
