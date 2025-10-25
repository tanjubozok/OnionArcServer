using OnionArc.Application.Conctract.Persistence;
using OnionArc.Persistence.Context;

namespace OnionArc.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync() 
        => await _context.SaveChangesAsync();
}
