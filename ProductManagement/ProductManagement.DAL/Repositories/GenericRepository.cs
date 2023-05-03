using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL.Data;
using ProductManagement.DAL.Interfaces;
using System.Linq.Expressions;

namespace ProductManagement.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly ProductManagementDbContext _context;

        public GenericRepository(ProductManagementDbContext context)
        {
            this._context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
