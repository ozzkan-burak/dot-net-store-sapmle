using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
  public class ProductController : Controller
  {

    public readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
      _manager = manager;
    }
    public IActionResult Index()
    {
      var model = _manager.ProductService.GetAllProducts(false);
      return View(model);
    }
    public IActionResult GetProduct([FromRoute(Name = "id")] int id)
    {
      //Product product = _context.Products.First(p => p.ProductId.Equals(id));
      var model = _manager.ProductService.GetProduct(id, false);
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
