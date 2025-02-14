using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Data.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProductById(Guid productId);

        Task<Product> CreateProduct(Product product);

        Task<Product?> UpdateProduct(Product product);

        Task<Product?> DeleteProduct(Guid productId);
    }
}
