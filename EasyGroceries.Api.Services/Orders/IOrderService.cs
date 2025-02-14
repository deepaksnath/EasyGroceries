using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Services.Orders
{
    public interface IOrderService
    {
        Task<Order?> PlaceOrder(Order order);
    }
}
