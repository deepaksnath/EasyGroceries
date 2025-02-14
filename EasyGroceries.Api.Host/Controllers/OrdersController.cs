using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace EasyGroceries.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            Order? placedOrder = await _orderService.PlaceOrder(order);
            if (placedOrder is not null)
            {
                return Ok(placedOrder);
            }
            return BadRequest();
        }
    }
}
