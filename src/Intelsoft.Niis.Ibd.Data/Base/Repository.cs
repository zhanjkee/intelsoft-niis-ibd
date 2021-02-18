using System;
using System.Linq;
using System.Linq.Expressions;
using Intelsoft.Niis.Ibd.Data.Interfaces;
using Intelsoft.Niis.Ibd.Data.Interfaces.Base;
using Intelsoft.Niis.Ibd.Entities.Base;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Intelsoft.Niis.Ibd.Data.Base
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IDataContext _context;

        public Repository([NotNull] IDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbSet<T> DbSet => _context.Set<T>();

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Find(entity.Id);
            DbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            var originalEntity = DbSet.Find(entity.Id);
            _context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }
    }
}