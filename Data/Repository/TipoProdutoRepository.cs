using Model;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Data.Repository
{
    public class TipoProdutoRepository
    {
        TipoProduto GetById(int id)
        {
            return null;
        }

        IQueryable<TipoProduto> GetAll(Expression<Func<TipoProduto, bool>> filter)
        {
            return null;
        }

        bool Save(TipoProduto entity)
        {
            return true;
        }

        bool Delete(int id)
        {
            return true;
        }

        bool Delete(TipoProduto entity)
        {
            return true;
        }
    }
}
