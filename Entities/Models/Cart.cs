
namespace Entities.Models
{
  public class Cart
  {
    public List<CartLine> Lines { get; set; }

    public Cart()
    {
      Lines = new List<CartLine>();
    }

    public virtual void AddItem(Product product, int quantity)
    {
      CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();
      if (line == null)
      {
        line = new CartLine { Product = product, Quantity = quantity };
        Lines.Add(line);
      }
      else
      {
        line.Quantity += quantity;
      }
    }

    public virtual void RemoveLine(Product product)
    {
      CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();
      if (line != null)
      {
        Lines.Remove(line);
      }
    }

    public virtual void RemoveItem(Product product, int quantity = 1)
    {
      CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();
      if (line != null)
      {
        line.Quantity -= quantity;
        if (line.Quantity <= 0)
        {
          Lines.Remove(line);
        }
      }
    }

    public decimal TotalValue => Lines.Sum(e => e.Product.Price * e.Quantity);

    public int TotalCount => Lines.Sum(e => e.Quantity);

    public virtual void Clear() => Lines.Clear();

  }
}