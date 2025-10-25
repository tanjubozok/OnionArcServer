using Microsoft.EntityFrameworkCore;
using OnionArc.Application.Conctract.Persistence;
using OnionArc.Domain.Entities.Common;
using OnionArc.Persistence.Context;
using System.Linq.Expressions;

namespace OnionArc.Persistence.Concrete;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public async Task DeleteAsync(T entity)
        => await Task.Run(() => { _dbSet.Remove(entity); });

    public async Task<List<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(Guid guid)
        => await _dbSet.FindAsync(guid);

    public Task<IQueryable> GetQueryableAsync()
        => Task.FromResult(_dbSet.AsQueryable() as IQueryable);

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);

    public async Task UpdateAsync(T entity)
        => await Task.Run(() => { _dbSet.Update(entity); });
}