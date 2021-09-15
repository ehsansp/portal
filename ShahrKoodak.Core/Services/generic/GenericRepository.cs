using Microsoft.EntityFrameworkCore;
using PortalBuilder.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PortalBuilder.Core.Services.generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ShahrContext _context;
        protected DbSet<T> DbSet { get; set; }
        public GenericRepository(ShahrContext context)
        {
            _context = context;
             DbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children)
        {
            try
            {
                IQueryable<T> query = DbSet;
                foreach (string entity in children)
                {
                    query = query.Include(entity);

                }
                return  query.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}