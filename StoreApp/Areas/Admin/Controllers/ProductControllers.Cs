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
      ViewBag.Categories = GetCategoriesSelectlist();
      return View();
    }

    private SelectList GetCategoriesSelectlist()
    {
      return new SelectList(_manager.CategoryService.GetAllCategories(false),
      "CategoryId",
      "CategoryName",
      "1");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile imageFile)
    {
      if (ModelState.IsValid)
      {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
          await imageFile.CopyToAsync(stream);
        }
        productDto.ImageUrl = String.Concat("/images/", imageFile.FileName);
        _manager.ProductService.CreateProduct(productDto);
        return RedirectToAction("Index");
      }
      return View();
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
      ViewBag.Categories = GetCategoriesSelectlist();
      var model = _manager.ProductService.GetProductForUpdate(id, false);
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile imageFile)
    {
      if (ModelState.IsValid)
      {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
          await imageFile.CopyToAsync(stream);
        }
        productDto.ImageUrl = String.Concat("/images/", imageFile.FileName);
        _manager.ProductService.UpdateOneProduct(productDto);
        return RedirectToAction("Index");
      }
      ViewBag.Categories = GetCategoriesSelectlist();
      return View(productDto);
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



