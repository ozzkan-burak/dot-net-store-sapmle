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
      _manager.Product.CreateoneProduct(product);
      _manager.Save();
    }

    public void DeleteOneProduct(Product product)
    {
      Product productFromDb = _manager.Product.GetOneProduct(product.ProductId, false);
      if (productFromDb is not null)
      {
        _manager.Product.DeleteOneProduct(productFromDb);
        _manager.Save();
      }

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
      return _manager.Product.GetOneProduct(id, trackChanges);
    }
  }
}
