namespace Repositories.Contracts
{
  public class RepositoryManager : IRepositoryManager
  {
    private readonly RepositoryContext _context;
    private readonly IProductRepository _productRepository;

    public RepositoryManager(IProductRepository productRepository, RepositoryContext context)
    {
      _context = context;
      _productRepository = productRepository;
    }

    // Product özelliği artık _productRepository'yi döndürüyor
    public IProductRepository Product => _productRepository;

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}