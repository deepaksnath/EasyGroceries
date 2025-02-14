using EasyGroceries.Api.Data.Carts;
using EasyGroceries.Api.Data.Customers;
using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Data.Orders;

namespace EasyGroceries.Api.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, 
                            ICartRepository cartRepository,
                            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }
        public async Task<Order?> PlaceOrder(Order order)
        {
            if (order.CustomerId != Guid.Empty)
            {
                var customer = await _customerRepository.GetCustomerById(order.CustomerId);
                var cartItems = await _cartRepository.GetCartItemsByCustomerAsync(order.CustomerId);
                if (customer is not null &&
                    cartItems is not null &&
                    cartItems.Any(i => i.Quantity > 0))
                {
                    if (order.IsLoyaltyMembershipAdded)
                    {
                        cartItems.Add(new()
                        {
                            CustomerId = order.CustomerId,
                            Price = ServiceConstants.LOYALTY_MEMBERSHIP_PRICE,
                            Quantity = 1
                        });
                        customer.HasLoyaltyMembership = true;
                    }
                    var discount = ServiceConstants.LOYALTY_MEMBER_DISCOUNT;
                    List<OrderItem> orderItems = new();
                    decimal totalPrice = 0;
                    foreach (var cartItem in cartItems)
                    {
                        var unitPrice = cartItem.Price;
                        if(cartItem.ProductId != Guid.Empty)
                        {
                            cartItem.ProductId = Guid.NewGuid();
                            unitPrice = customer.HasLoyaltyMembership ?
                                    (unitPrice - (unitPrice * discount)) :
                                    unitPrice;
                        }
                        OrderItem orderItem = new()
                        {
                            CustomerId = cartItem.CustomerId,
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                            Price = unitPrice
                        };
                        orderItems.Add(orderItem);
                        totalPrice += orderItem.Price * cartItem.Quantity;
                    }

                    order.TotalAmount = totalPrice;
                    order.OrderDate = DateTime.Now;
                    await _orderRepository.CreateOrder(order);

                    orderItems.ForEach(item => { item.OrderId = order.Id; });

                    await _orderRepository.CreateOrderItems(orderItems);

                    await _cartRepository.RemoveCartItemsByCustomerAsync(order.CustomerId);
                    
                    if (order.IsLoyaltyMembershipAdded)
                    {
                        await _customerRepository.UpdateCustomer(customer);
                    }
                    return order;
                }
            }
            return null;
        }
    }
}
