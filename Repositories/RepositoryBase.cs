using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T>
  where T : class, new()
  {
    protected readonly RepositoryContext _context;

    protected RepositoryBase(RepositoryContext context)
    {
      _context = context;
    }
    public IQueryable<T> FindAll(bool trackChanges)
    {
      return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
    }
  }
}