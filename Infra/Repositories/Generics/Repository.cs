using Domain.Generics;
using Domain.Interfaces.Generics;
using Infra.DatabaseContext;
using System;
using System.Linq;

namespace Infra.Repositories.Generics
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly SsDbContext _context;

        public Repository(SsDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get(Func<T, bool> searchLambda) =>
            _context.Set<T>().Where(searchLambda).AsQueryable();

        public T GetById(int id) => _context.Set<T>().FirstOrDefault(g => g.Id == id);

        public T Insert(T entity)
        {
            if (entity.IsValid())
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();

                return entity;
            }

            throw new FormatException("Entity missing required fields");
        }

        public T Update(T entity)
        {
            if (entity.IsValid())
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();

                return entity;
            }

            throw new FormatException("Entity missing required fields");
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}