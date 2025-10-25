using OnionArc.Domain.Entities.Common;
using System.Linq.Expressions;

namespace OnionArc.Application.Conctract.Persistence;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<IQueryable> GetQueryableAsync();

    Task<T?> GetByIdAsync(Guid guid);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression);

    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
