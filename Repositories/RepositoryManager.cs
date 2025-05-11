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
    public IProductRepository Product => throw new NotImplementedException();

    public void Save()
    {
      throw new NotImplementedException();
    }
  }
}