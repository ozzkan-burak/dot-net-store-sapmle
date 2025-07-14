using Entities.Models;

namespace Repositories.Contracts
{
  public interface IProductRepository : IRepositoryBase<Product>
  {
    IQueryable<Product> GetAllProducts(bool trackChanges);
    Product? GetOneProduct(int id, bool trackChanges);
    void CreateoneProduct(Product product);
    void DeleteOneProduct(Product product);
  }
}