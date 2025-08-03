using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
  public interface IProductService
  {
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    Product? GetProduct(int id, bool trackChanges);
    void CreateProduct(ProductDtoForInsertion productDto);
    void UpdateOneProduct(ProductDtoForUpdate productDto);
    void DeleteOneProduct(Product product);
    ProductDtoForUpdate GetProductForUpdate(int id, bool trackChanges);
  }


}