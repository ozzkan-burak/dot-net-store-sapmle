using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
  public class ShowCartTotalItemsViewComponent : ViewComponent
  {
    private readonly Cart _cart;

    public ShowCartTotalItemsViewComponent(Cart cartService)
    {
      _cart = cartService;
    }
    public IViewComponentResult Invoke()
    {
      return Content(_cart.Lines.Count().ToString());
    }
  }
}