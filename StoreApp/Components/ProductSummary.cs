using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace StoreApp.Components
{
  public class ProductSummary : ViewComponent
  {
    private readonly RepositoryContext _context;
    public ProductSummary(RepositoryContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }
  }
}