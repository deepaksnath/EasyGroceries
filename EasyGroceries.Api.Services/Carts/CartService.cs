using EasyGroceries.Api.Data.Carts;
using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            return await _cartRepository.AddCartItem(cartItem);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCustomerAsync(Guid customerId)
        {
            return await _cartRepository.GetCartItemsByCustomerAsync(customerId);
        }

        public async Task<CartItem?> UpdateCartItem(CartItem cartItem)
        {
            return await _cartRepository.UpdateCartItem(cartItem);
        }
    }
}
