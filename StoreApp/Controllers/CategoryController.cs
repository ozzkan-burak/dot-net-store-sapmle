using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
  public class CategoryController : Controller
  {
    private IRepositoryManager _manager;
    public CategoryController(IRepositoryManager manager)
    {
      _manager = manager;
    }

    public IActionResult index()
    {
      var model = _manager.Category.FindAll(false); // false parametresi, silinmiş kategorileri dahil etmemek için kullanılır
      return View(model);
    }
  }
}