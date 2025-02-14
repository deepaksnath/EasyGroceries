using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Host.Controllers;
using EasyGroceries.Api.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EasyGroceries.Api.Host.Test.Products
{
    public class ProductsControllerTests
    {
        private Mock<IProductService> _productService;
        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
        }

        [Test]
        public void Test_Get_Success()
        {
            //Arrange
            Product? product = new()
            {
                Id = Guid.Empty
            };
            _productService.Setup(ss => ss.GetProductById(It.IsAny<Guid>()).Result)
                           .Returns(product);
            ProductsController productsController = new(_productService.Object);

            //Act
            var response = productsController.Get(Guid.Empty);
            var result = response.Result as OkObjectResult;

            //Assert
            Assert.That(result?.StatusCode, Is.EqualTo(200));
        }
    }
}
