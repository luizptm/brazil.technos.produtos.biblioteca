﻿using System.Collections.Generic;

namespace Data.Repository
{
    public interface IRepository<T> where T : class
    {
        public T Get(int id);
        public List<T> GetAll();
        public PagedResultDto<T> GetPagedData(int maxCountReg, int skip);
        public List<T> Find(T produto);
        public bool Salvar(T entity);
        public bool Excluir(int id);
        public bool Excluir(T entity);
    }
}
