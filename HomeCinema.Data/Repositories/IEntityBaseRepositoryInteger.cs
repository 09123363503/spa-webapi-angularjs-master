﻿using HomeCinema.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HomeCinema.Data.Repositories
{
    //public interface IEntityBaseRepository { }

    public interface IEntityBaseRepositoryInetger<T> where T : class, IEntityBaseInteger, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
