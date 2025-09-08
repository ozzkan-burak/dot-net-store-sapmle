using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
  public class DemoModel : PageModel
  {
    public String? FullName { get; set; }
    public IActionResult OnPost([FromForm] string inputData)
    {
      FullName = inputData;
      // Handle form submission
      return RedirectToPage("/Index");
    }
  }
}