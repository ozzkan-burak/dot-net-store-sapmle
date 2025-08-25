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

    public Cart Cart { get; set; } = new Cart();

    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
      ReturnUrl = returnUrl ?? "/";
      Cart = new Cart();
    }

    public IActionResult OnPost(int productId, string returnUrl)
    {
      Product? product = _manager.ProductService.GetProduct(productId, false);
      if (product is null)
      {
        return NotFound();
      }

      Cart = new Cart();
      Cart.AddItem(product, 1);

      return Page();
    }

    public IActionResult OnPostRemove(int id, string returnUrl)
    {
      Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
      return Page();
    }
  }
}