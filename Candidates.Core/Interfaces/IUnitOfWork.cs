using Candidates.Core.Models;

namespace Candidates.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;
        Task<int> SaveChangesAsync();
    }
}
