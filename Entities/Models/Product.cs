
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
  public int ProductId { get; set; }
  [Required(ErrorMessage = "Product name is required.")]
  public String? ProductName { get; set; }
  public decimal Price { get; set; }
}
