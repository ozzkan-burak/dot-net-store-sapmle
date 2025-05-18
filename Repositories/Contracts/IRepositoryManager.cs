namespace Repositories.Contracts
{
  public interface IRepositoryManager
  {
    public IProductRepository Product { get; }
    public ICategoryRepository Category { get; }
    void Save();
  }
}