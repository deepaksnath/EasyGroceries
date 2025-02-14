using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProductById(Guid productId);

        Task<Product> CreateProduct(Product product);

        Task<Product?> UpdateProduct(Product product);

        Task<Product?> DeleteProduct(Guid productId);
    }
}
