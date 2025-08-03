using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
  public class ProductManager : IProductService
  {
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public ProductManager(IRepositoryManager manager, IMapper mapper)
    {
      _manager = manager ?? throw new ArgumentNullException(nameof(manager));
      _mapper = mapper;
    }

    public void CreateProduct(ProductDtoForInsertion productDto)
    {
      Product product = _mapper.Map<Product>(productDto);
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

    public ProductDtoForUpdate GetProductForUpdate(int id, bool trackChanges)
    {
      var product = GetOneProduct(id, trackChanges);
      var productDto = _mapper.Map<ProductDtoForUpdate>(product);
      return productDto;
    }

    public void UpdateOneProduct(ProductDtoForUpdate productDto)
    {
      //var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);

      // entity.ProductName = productDto.ProductName;
      // entity.Price = productDto.Price;
      // entity.CategoryId = productDto.CategoryId;
      var entity = _mapper.Map<Product>(productDto);
      if (entity is null)
      {
        throw new KeyNotFoundException($"Product with id {productDto.ProductId} not found.");
      }
      _manager.Product.UpdateOneProduct(entity);
      _manager.Save();
    }
  }
}

