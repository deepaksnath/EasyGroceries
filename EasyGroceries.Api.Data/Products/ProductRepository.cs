using EasyGroceries.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyGroceries.Api.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly EasyDBContext _dbContext;
        public ProductRepository(EasyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProduct(Guid productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product is not null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            return product;
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProductExists(Guid id)
        {
            return _dbContext.Products.Any(e => e.Id == id);
        }
    }
}
