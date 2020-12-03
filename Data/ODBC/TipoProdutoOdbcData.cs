using Data.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Data.ODBC
{
    public class TipoProdutoOdbcData : ITipoProdutoOdbcData
    {
        private string connectionString = "";

        public TipoProdutoOdbcData()
        {
            connectionString = ConfigurationManager.ConnectionStrings["GrupoTechnos"].ConnectionString;
        }
        bool IRepository<TipoProduto>.Excluir(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<TipoProduto>.Excluir(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        List<TipoProduto> IRepository<TipoProduto>.Find(TipoProduto produto)
        {
            throw new NotImplementedException();
        }

        TipoProduto IRepository<TipoProduto>.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<TipoProduto> IRepository<TipoProduto>.GetAll()
        {
            throw new NotImplementedException();
        }

        PagedResultDto<TipoProduto> IRepository<TipoProduto>.GetPagedData(int maxCountReg, int skip)
        {
            throw new NotImplementedException();
        }

        bool IRepository<TipoProduto>.Salvar(TipoProduto entity)
        {
            throw new NotImplementedException();
        }
    }
}
