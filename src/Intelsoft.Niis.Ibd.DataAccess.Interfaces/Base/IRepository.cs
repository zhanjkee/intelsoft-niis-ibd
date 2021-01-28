using System;
using System.Linq;
using System.Linq.Expressions;
using Intelsoft.Niis.Ibd.Entities.Base;

namespace Intelsoft.Niis.Ibd.DataAccess.Interfaces.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
