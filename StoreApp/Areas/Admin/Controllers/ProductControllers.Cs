using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class ProductController : Controller
  {

    private readonly IServiceManager _manager;
    public ProductController(IServiceManager manager)
    {
      _manager = manager;
    }
    public IActionResult Index()
    {
      var model = _manager.ProductService.GetAllProducts(false);
      return View(model);
    }

    public IActionResult Create()
    {
      ViewBag.Categories = new SelectList(_manager.CategoryService.GetAllCategories(false),
      "CategoryId",
      "CategoryName",
      "1");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
    {
      if (ModelState.IsValid)
      {
        _manager.ProductService.CreateProduct(productDto);
        return RedirectToAction("Index");
      }
      return View();
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
      var model = _manager.ProductService.GetProductForUpdate(id, false);
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Product product)
    {
      return View();
    }

    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
      var product = _manager.ProductService.GetProduct(id, false);
      if (product != null)
      {
        _manager.ProductService.DeleteOneProduct(product);
      }
      return RedirectToAction("Index");
    }
  }
}



