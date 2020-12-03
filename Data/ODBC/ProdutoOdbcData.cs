using Data.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ODBC
{
    public class ProdutoOdbcData : IProdutoOdbcData
    {
        bool IRepository<Produto>.Excluir(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Produto>.Excluir(Produto entity)
        {
            throw new NotImplementedException();
        }

        List<Produto> IRepository<Produto>.Find(Produto produto)
        {
            throw new NotImplementedException();
        }

        Produto IRepository<Produto>.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Produto> IRepository<Produto>.GetAll()
        {
            throw new NotImplementedException();
        }

        PagedResultDto<Produto> IRepository<Produto>.GetPagedData(int maxCountReg, int skip)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Produto>.Salvar(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
}
