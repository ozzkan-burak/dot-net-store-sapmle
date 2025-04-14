using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using Entities.Models;

namespace StoreApp.Controllers
{
  public class ProductController : Controller
  {

    public readonly RepositoryContext _context;

    public ProductController(RepositoryContext context)
    {
      _context = context;
    }
    public IActionResult Index()
    {
      var model = _context.Products.ToList();
      return View(model);
    }
    public IActionResult GetProduct(int id)
    {
      Product product = _context.Products.First(p => p.ProductId.Equals(id));
      return View(product);
    }
  }
}
