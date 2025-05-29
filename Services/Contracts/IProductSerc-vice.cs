using Entities.Models;

namespace Services.Contracts
{
  public interface IProductService
  {
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    Product? GetProduct(Guid id, bool trackChanges);
  }
}