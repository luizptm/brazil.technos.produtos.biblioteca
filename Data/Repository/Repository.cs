using Data;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace dbSet.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> dbSet;

        public Repository(DbSet<T> dbSet)
        {
            this.dbSet = dbSet;
        }

        public T Get(Int32 codigo)
        {
            return null;
        }

        public List<T> GetAll()
        {
            return null;
        }

        public PagedResultDto<T> GetPagedData(int maxCountReg, int skip)
        {
            return null;
        }

        public List<T> Find(T T)
        {
            return null;
        }

        public Boolean Salvar(T T)
        {
            return false;
        }

        public Boolean Excluir(Int32 codigo)
        {
            return false;
        }

        public Boolean Excluir(T T)
        {
            return false;
        }
    }
}
