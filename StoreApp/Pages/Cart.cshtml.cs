using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities.Models;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Pages
{
  public class CartModel : PageModel
  {
    private readonly IServiceManager _manager;

    public CartModel(IServiceManager serviceManager)
    {
      _manager = serviceManager;
    }

    public Cart Cart { get; set; } = new Cart(); // Burada initialize edin

    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
      ReturnUrl = returnUrl ?? "/";
      Cart = new Cart(); // Veya session'dan yükleyin
    }

    public IActionResult OnPost(int productId, string returnUrl)
    {
      Product? product = _manager.ProductService.GetProduct(productId, false);
      if (product is null)
      {
        return NotFound();
      }

      Cart = new Cart(); // Cart'ı initialize edin
      Cart.AddItem(product, 1); // Artık çalışacak

      return RedirectToPage(new { returnUrl = returnUrl });
    }
  }
}