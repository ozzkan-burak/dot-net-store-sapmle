using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
  public class ProductController : Controller
  {

    public readonly IRepositoryManager _manager;

    public ProductController(IRepositoryManager manager)
    {
      _manager = manager;
    }
    public IActionResult Index()
    {
      var model = _manager.Product.GetAllProducts(false);
      return View(model);
    }
    public IActionResult GetProduct(int id)
    {
      //Product product = _context.Products.First(p => p.ProductId.Equals(id));
      var model = _manager.Product.GetOneProduct(id, false);
      if (model == null)
      {
        return NotFound();
      }
      else
      {
        return View(model);
      }
    }
  }
}
