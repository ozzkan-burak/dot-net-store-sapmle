namespace Repositories.Contracts
{
  public interface IRepositoryManager
  {
    public IProductRepository Product { get; }
    void Save();
  }
}