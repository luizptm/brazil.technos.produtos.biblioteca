using Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class ProdutoRepository
    {
        Produto GetById(int id)
        {
            return null;
        }

        IQueryable<Produto> GetAll(Expression<Func<Produto, bool>> filter)
        {
            return null;
        }

        bool Save(Produto entity)
        {
            return true;
        }

        bool Delete(int id)
        {
            return true;
        }

        bool Delete(Produto entity)
        {
            return true;
        }
    }
}
