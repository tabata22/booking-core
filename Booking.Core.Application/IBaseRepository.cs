using System.Linq.Expressions;
using Booking.Core.Domain;

namespace Booking.Core.Application;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<TEntity?> GetForUpdateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task SaveAsync(CancellationToken cancellationToken = default);
}