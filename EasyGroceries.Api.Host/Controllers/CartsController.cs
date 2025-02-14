using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Services.Carts;
using Microsoft.AspNetCore.Mvc;

namespace EasyGroceries.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartItem cartItem)
        {
            CartItem? item = await _cartService.AddCartItem(cartItem);
            if (item is not null)
            {
                return Ok(item);
            }
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CartItem cartItem)
        {
            CartItem? item = await _cartService.UpdateCartItem(cartItem);
            if (item is not null)
            {
                return Ok(item);
            }
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            var products = await _cartService.GetCartItemsByCustomerAsync(customerId);
            return Ok(products);
        }
    }
}
