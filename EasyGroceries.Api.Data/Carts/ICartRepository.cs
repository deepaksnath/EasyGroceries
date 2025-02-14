using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Data.Carts
{
    public interface ICartRepository
    {
        Task<CartItem> AddCartItem(CartItem cartItem);
        Task<CartItem?> UpdateCartItem(CartItem cartItem);
        Task<IList<CartItem>> GetCartItemsByCustomerAsync(Guid customerId);
        Task<bool> RemoveCartItemsByCustomerAsync(Guid customerId);
    }
}
