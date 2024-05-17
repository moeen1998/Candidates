using Azure;
using Candidates.Core.Interfaces;
using Candidates.Core.Models;
using Candidates.EF.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Candidates.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return query.FirstOrDefault(criteria);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return await query.FirstOrDefaultAsync(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return query.Where(criteria).ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void PermanentDelete(ICollection<T> entities)
        {
             _context.Set<T>().RemoveRange(entities);
        }

        public bool IsExist(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return query.Any(criteria);
        }

    }
}
