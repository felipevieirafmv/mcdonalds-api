using System.Collections.Generic;
using System.Threading.Tasks;
using McDonaldsAPI.Model;

namespace McDonaldsAPI.Services;

public interface IOrderRepository
{
    Task<string> CreateOrder(int store);
    Task CancelOrder(int orderCode);
    Task<List<Product>> GetMenu(int orderId);
    Task<List<Product>> GetOrderItems(int orderId);
    Task AddItem(int orderId, int productId);
    Task RemoveItem(int orderId, int productId);
    Task FinishOrder(int orderId);
    Task DeliveryOrder(int orderId);
}
