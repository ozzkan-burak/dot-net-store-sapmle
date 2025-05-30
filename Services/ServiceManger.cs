using Services.Contracts;

namespace Services
{
  public class ServiceManager : IServiceManager
  {
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ServiceManager(IProductService productService, ICategoryService categoryService)
    {
      _productService = productService ?? throw new ArgumentNullException(nameof(productService));
      _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }
    ICategoryService IServiceManager.CategoryService => _categoryService;

    IProductService IServiceManager.ProductService => _productService;
  }
}