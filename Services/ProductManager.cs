using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
  public class ProductManager : IProductService
  {
    private readonly IRepositoryManager _manager;

    public ProductManager(IRepositoryManager manager)
    {
      _manager = manager ?? throw new ArgumentNullException(nameof(manager));
    }

    public void CreateProduct(Product product)
    {
      _manager.Product.CreateProduct(product);
      _manager.Save();
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
      return _manager.Product.GetAllProducts(trackChanges);
    }
    public Product? GetOneProduct(int id, bool trackChanges)
    {
      var product = _manager.Product.GetOneProduct(id, trackChanges);
      if (product is null)
      {
        throw new KeyNotFoundException($"Product with id {id} not found.");
      }
      return product;
    }

    public Product? GetProduct(int id, bool trackChanges)
    {
      throw new NotImplementedException();
    }
  }
}
