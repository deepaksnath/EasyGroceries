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

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
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
            Product? product = await _productService.GetProductById(id);
            if (product is not null)
            {
                return Ok(product);
            }
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
            Product? newProduct = await _productService.CreateProduct(product);
            if (newProduct is not null)
            {
                return Ok(newProduct);
            }
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
            Product? newProduct = await _productService.UpdateProduct(product);
            if (newProduct is not null)
            {
                return Ok(newProduct);
            }
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
            Product? product = await _productService.DeleteProduct(id);
            if (product is not null)
            {
                return Ok(product);
            }
            return NotFound();
        }
    }
}
