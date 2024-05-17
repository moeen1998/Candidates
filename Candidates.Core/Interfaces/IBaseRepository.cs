using System.Linq.Expressions;

namespace Candidates.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        bool IsExist(Expression<Func<T, bool>> criteria);

        T Find(Expression<Func<T, bool>> criteria);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria);
        
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
                
        Task<T> Add(T entity);
        
        T Update(T entity);
        
        void Delete(T entity);

        void PermanentDelete(ICollection<T> entities);
    }
}
