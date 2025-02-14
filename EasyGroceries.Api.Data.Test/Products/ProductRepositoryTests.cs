using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Data.Products;
using Microsoft.EntityFrameworkCore;

namespace EasyGroceries.Api.Data.Test.Products
{
    public class ProductRepositoryTests
    {
        [Test]
        public async Task Test_GetProductById_Success()
        {
            //Arrange
            string productId = "f5701b30-5efa-433a-1be8-08dcf928f5cf";
            List<Product> initialData = new()
            {
                new()
                {
                    Id = new Guid(productId),
                    Name = "Pepsi"
                }
            };
            var options = new DbContextOptionsBuilder<EasyDBContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            using var context = new EasyDBContext(options);
            context.Products.AddRange(initialData);
            await context.SaveChangesAsync();

            ProductRepository productRepository = new(context);

            //Act
            var result = await productRepository.GetProductById(new Guid(productId));
            
            //Assert
            Assert.That(result?.Id.ToString(), Is.EqualTo(productId));
        }
    }
}