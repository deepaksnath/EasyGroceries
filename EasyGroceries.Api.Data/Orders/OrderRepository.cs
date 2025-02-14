using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Data.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EasyDBContext _dbContext;

        public OrderRepository(EasyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CreateOrderItems(List<OrderItem> orderItems)
        {
            await _dbContext.OrderItems.AddRangeAsync(orderItems);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
