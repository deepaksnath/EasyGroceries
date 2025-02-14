using EasyGroceries.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyGroceries.Api.Data.Carts
{
    public class CartRepository : ICartRepository
    {
        private readonly EasyDBContext _dbContext;
        public CartRepository(EasyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            cartItem.Id = Guid.NewGuid();
            await _dbContext.CartItems.AddAsync(cartItem);
            await _dbContext.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem?> UpdateCartItem(CartItem cartItem)
        {
            CartItem? existingItem = await _dbContext.CartItems
                                           .FirstOrDefaultAsync(i=>i.ProductId == cartItem.ProductId);
            if (existingItem is not null)
            {
                _dbContext.Entry(existingItem).CurrentValues.SetValues(cartItem);
                await _dbContext.SaveChangesAsync();
                return existingItem;
            }
            return null;
        }

        public async Task<IList<CartItem>> GetCartItemsByCustomerAsync(Guid customerId)
        {
            return await _dbContext.CartItems.Where(c=>c.CustomerId == customerId).ToListAsync();
        }

        public async Task<bool> RemoveCartItemsByCustomerAsync(Guid customerId)
        {
           var items = _dbContext.CartItems.Where(x => x.CustomerId == customerId);
           _dbContext.CartItems.RemoveRange(items);
           await _dbContext.SaveChangesAsync();
           return true;
        }
    }
}
