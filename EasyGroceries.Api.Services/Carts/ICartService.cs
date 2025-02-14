using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Services.Carts
{
    public interface ICartService
    {
        Task<CartItem> AddCartItem(CartItem cartItem);
        Task<CartItem> UpdateCartItem(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetCartItemsByCustomerAsync(Guid customerId);
    }
}
