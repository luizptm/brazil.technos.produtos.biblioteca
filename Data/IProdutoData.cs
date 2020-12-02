using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IProdutoData
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
