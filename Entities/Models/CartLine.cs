namespace Entities.Models
{
  public class CartLine
  {
    public int CartLineId { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; } = new();
  }
}