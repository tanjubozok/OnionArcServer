namespace OnionArc.Application.Conctract.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
