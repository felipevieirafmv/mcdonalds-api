using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using McDonaldsAPI.Model;

namespace McDonaldsAPI.Services;

public class FakeOrderRepository : IOrderRepository
{
    int orderId = 42;
    public Task AddItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }

    public async Task CancelOrder(int orderId)
    {
        orderId = Random.Shared.Next();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        return orderId;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }
}