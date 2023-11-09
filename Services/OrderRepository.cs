using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace McDonaldsAPI.Services;

using McDonaldsAPI.Model;

public class OrderRepository : IOrderRepository
{
    private readonly McDataBaseContext ctx;
    public OrderRepository(McDataBaseContext ctx)
        => this.ctx = ctx;
    
    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore =
            from store in ctx.Stores
            where store.Id == storeId
            select store;
        if (selectedStore.Count() == 0)
            throw new System.Exception("Store doesn't exists.");

        var clientOrder = new ClientOrder();
        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "abcd1234";

        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();
        
        return clientOrder.Id;
    }
    
    public async Task CancelOrder(int orderId)
    {
        var currentOrder = await getOrder(orderId);
        if (currentOrder is null)
            throw new Exception("The order doesn't exists");

        ctx.Remove(currentOrder);
        await ctx.SaveChangesAsync();
    }
    
    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task AddItem(int orderId, int productId)
    {
        var order = getOrder(orderId);
        if (order is null)
            throw new Exception("Order doesn't exists.");
        
        var products = 
            from product in ctx.Products
            where product.Id == productId 
            select product;
        var selectedProduct = await products
            .FirstOrDefaultAsync();
        if (selectedProduct is null)
            throw new Exception("Product doesn't exists.");
        
        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = productId;

        ctx.Add(item);
        await ctx.SaveChangesAsync();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new NotImplementedException();
    }
    public Task DeliveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    private async Task<ClientOrder> getOrder(int orderId)
    {
        var orders = 
            from order in ctx.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }        
}