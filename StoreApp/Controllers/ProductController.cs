using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Controllers
{
  public class ProductController : Controller
  {
    public IEnumerable<Product> Index()
    {

      var context = new RepositoryContext(
        new DbContextOptionsBuilder<RepositoryContext>()
          .UseSqlite("Data Source = C:\\DB\\ProductDB.db")
          .Options
      );
      return context.Products.ToList();
    }
  }
}