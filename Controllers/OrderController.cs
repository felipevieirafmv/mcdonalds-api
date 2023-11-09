using System;
using System.Linq;
using McDonaldsAPI.Model;
using McDonaldsAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace McDonaldsAPI.Controllers;

[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{
    private readonly McDataBaseContext ctx;
    public OrderController (McDataBaseContext ctx)
        => this.ctx = ctx;

    [HttpPost("create/{storeId}")]
    public async Task<ActionResult> CreateOrder(int storeId, [FromServices]IOrderRepository repo)
    {
        try
        {
            var orderId = await repo.CreateOrder(storeId);
            return Ok(orderId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("actives")]
    public async Task<ActionResult> GetActives()
    {
        var query = 
            from clientOrder in ctx.ClientOrders
            where clientOrder.FinishMoment == null
            join clientOrderItem in ctx.ClientOrderItems
            on clientOrder.Id equals clientOrderItem.ClientOrderId
            select new{
                orderCode = clientOrder.OrderCode,
                orderStore = clientOrder.StoreId,
                product = clientOrderItem.ProductId
            };
    }
}
