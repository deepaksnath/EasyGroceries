using EasyGroceries.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyGroceries.Api.Data.Customers
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly EasyDBContext _dbContext;
        public CustomerRepository(EasyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteCustomer(Guid customerId)
        {

            var customer = await _dbContext.Customers.FindAsync(customerId);
            if (customer is not null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
            return customer;
        }

        public async Task<Customer?> GetCustomerById(Guid customerId)
        {
            return await _dbContext.Customers.FindAsync(customerId);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> UpdateCustomer(Customer customer)
        {

            try
            {
                _dbContext.Update(customer);
                await _dbContext.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool CustomerExists(Guid id)
        {
            return _dbContext.Customers.Any(e => e.Id == id);
        }
    }
}
