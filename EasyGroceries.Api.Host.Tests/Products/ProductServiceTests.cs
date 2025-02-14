using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Data.Products;
using EasyGroceries.Api.Services.Products;
using Moq;

namespace EasyGroceries.Api.Services.Test.Products
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _productRepository;
        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Test]
        public void Test_GetProductById_Success()
        {
            //Arrange
            Product? product = new()
            {
                Id = new Guid("f5701b30-5efa-433a-1be8-08dcf928f5cf")
            }; 
            _productRepository.Setup(x => x.GetProductById(It.IsAny<Guid>()).Result)
                              .Returns(product);
            ProductService productService = new(_productRepository.Object);

            //Act
            var response = productService.GetProductById(Guid.Empty);
            var result = response.Result;

            //Assert
            Assert.That(result?.Id.ToString(), Is.EqualTo("f5701b30-5efa-433a-1be8-08dcf928f5cf"));
        }
    }
}
