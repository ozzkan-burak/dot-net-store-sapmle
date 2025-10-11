using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities.Models;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Infrastructure.Extensions; // SessionExtensions için

namespace StoreApp.Pages
{
  public class CartModel : PageModel
  {
    private readonly IServiceManager _manager;

    public CartModel(IServiceManager serviceManager, Cart cartService)
    {
      _manager = serviceManager;
      Cart = cartService;
    }

    public Cart Cart { get; set; } = new Cart();
    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
      ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult OnPost(int productId, string returnUrl)
    {
      Product? product = _manager.ProductService.GetProduct(productId, false);
      if (product is null)
      {
        return NotFound();
      }

      Cart.AddItem(product, 1);

      // Kullanıcıyı doğrudan returnUrl'e yönlendir
      return RedirectToPage(new { returnUrl = returnUrl });
    }

    public IActionResult OnPostRemove(int id, string returnUrl)
    {
      // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
      var productToRemove = Cart.Lines.FirstOrDefault(cl => cl.Product.ProductId == id)?.Product;
      if (productToRemove != null)
      {
        Cart.RemoveLine(productToRemove);
        //HttpContext.Session.SetJson("cart", Cart);
      }

      return RedirectToPage(new { returnUrl = returnUrl });
    }
  }
}