using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Data.Products;

namespace EasyGroceries.Api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }

        public async Task<Product?> DeleteProduct(Guid productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }
    }
}
