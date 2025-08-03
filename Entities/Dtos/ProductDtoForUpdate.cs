using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
  public record ProductDtoForUpdate : ProductDto
  {
    public new int ProductId { get; set; }
    public new string? ProductName { get; set; }
    public new decimal Price { get; set; }
    public new int CategoryId { get; set; }
  }
}