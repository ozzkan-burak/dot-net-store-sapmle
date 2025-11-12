using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
  public class Order
  {
    public int OrderId { get; set; }

    public ICollection<CartLine> Lines { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required")]
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; } = string.Empty;
    public string? AddressLine3 { get; set; } = string.Empty;
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = string.Empty;
    public bool GiftWrap { get; set; }
    public bool Shipped { get; set; }
  }
}