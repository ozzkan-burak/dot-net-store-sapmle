using Entities.Models;

namespace Repositories.Contracts
{
  public interface IOrderRepository
  {
    IQueryable<Order> Orders { get; }
    Order? GetOrderById(int id);
    void Complete(int id);
    void SaveOrder(Order order);
  }

}