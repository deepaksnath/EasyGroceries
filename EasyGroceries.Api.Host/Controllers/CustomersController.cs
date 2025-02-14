using EasyGroceries.Api.Data.Entities;
using EasyGroceries.Api.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace EasyGroceries.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetCustomers();
            return Ok(customers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Customer? customer = await _customerService.GetCustomerById(id);
            if (customer is not null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            Customer? newCustomer = await _customerService.CreateCustomer(customer);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
            }
            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            Customer? newCustomer = await _customerService.UpdateCustomer(customer);
            if (newCustomer is not null)
            {
                return Ok(newCustomer);
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
            Customer? customer = await _customerService.DeleteCustomer(id);
            if (customer is not null)
            {
                return Ok(customer);
            }
            return NotFound();
        }
    }
}
