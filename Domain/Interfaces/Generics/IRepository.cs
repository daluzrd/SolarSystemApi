using Domain.Generics;
using System;
using System.Linq;

namespace Domain.Interfaces.Generics
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> Get(Func<T, bool> searchLambda);

        T GetById(int id);

        T Insert(T entity);

        T Update(T entity);

        void Delete(int id);
    }
}