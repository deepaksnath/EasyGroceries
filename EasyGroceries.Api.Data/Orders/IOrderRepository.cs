using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Data.Orders
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrder(Order order);
        Task<bool> CreateOrderItems(List<OrderItem> orderItems);
    }
}
