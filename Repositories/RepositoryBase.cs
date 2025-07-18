using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

    public void Create(T entity)
    {
      _context.Set<T>().Add(entity);
    }

    public void Remove(T entity)
    {
      _context.Set<T>().Remove(entity);
    }
    public IQueryable<T> FindAll(bool trackChanges)
    {
      return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
    }

    public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
      return !trackChanges
      ? _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault()
      : _context.Set<T>().Where(expression).SingleOrDefault();
    }
  }
}