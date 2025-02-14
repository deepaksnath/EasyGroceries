using EasyGroceries.Api.Data.Customers;
using EasyGroceries.Api.Data.Entities;

namespace EasyGroceries.Api.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await _customerRepository.CreateCustomer(customer);
        }

        public async Task<Customer?> DeleteCustomer(Guid customerId)
        {
            return await _customerRepository.DeleteCustomer(customerId);
        }

        public async Task<Customer?> GetCustomerById(Guid customerId)
        {
            return await _customerRepository.GetCustomerById(customerId); 
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customer?> UpdateCustomer(Customer customer)
        {
            return await _customerRepository.UpdateCustomer(customer);
        }
    }
}
