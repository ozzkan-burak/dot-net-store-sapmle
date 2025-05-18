namespace Repositories.Contracts
{
  public class RepositoryManager : IRepositoryManager
  {
    private readonly RepositoryContext _context;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public RepositoryManager(IProductRepository productRepository, ICategoryRepository categoryRepository, RepositoryContext context)
    {
      _context = context;
      _productRepository = productRepository;
      _categoryRepository = categoryRepository;
    }

    // Product özelliği artık _productRepository'yi döndürüyor
    public IProductRepository Product => _productRepository;
    public ICategoryRepository Category => _categoryRepository;

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}