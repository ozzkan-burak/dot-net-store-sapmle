using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
  public class DemoModel : PageModel
  {
    public String? FullName => HttpContext?.Session?.GetString("name") ?? "User";

    public void OnPost([FromForm] string inputData)
    {
      HttpContext?.Session?.SetString("name", inputData);
      //return Page();
    }
  }
}