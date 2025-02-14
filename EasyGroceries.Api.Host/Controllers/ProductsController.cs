using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EasyGroceries.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService,
                                  ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Request received to fetch all Products");
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation("Request received to fetch Product with id {Id}.", id);
            Product? product = await _productService.GetProductById(id);
            if (product is not null)
            {
                return Ok(product);
            }
            _logger.LogInformation("Product with id {Id} not found.", id);
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            _logger.LogInformation("Request received to create new Product.");
            Product? newProduct = await _productService.CreateProduct(product);
            if (newProduct is not null)
            {
                return Ok(newProduct);
            }
            _logger.LogError("Error creating the product");
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            _logger.LogInformation("Request received to update Product with id:{Id}.", product.Id);
            Product? newProduct = await _productService.UpdateProduct(product);
            if (newProduct is not null)
            {
                return Ok(newProduct);
            }
            _logger.LogError("Error updating the product");
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Request received to delete Product with id:{Id}.", id);
            Product? product = await _productService.DeleteProduct(id);
            if (product is not null)
            {
                return Ok(product);
            }
            _logger.LogInformation("Product with id {Id} not found.", id);
            return NotFound();
        }
    }
}
