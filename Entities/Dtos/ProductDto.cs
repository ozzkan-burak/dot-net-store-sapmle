using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
  public record ProductDto
  {
    public int ProductId { get; init; }
    [Required(ErrorMessage = "Product name is required.")]
    public String? ProductName { get; init; }
    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; init; }
    public int CategoryId { get; init; }
  }
}