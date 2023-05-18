using ECommerce.Customer.Exceptions;
using ECommerce.Customer.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Customer>().FindAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }

        public async Task<EntityEntry<Customer>> AddAsync(Customer customer)
        {
            var newCustomer = await _dbContext.Set<Customer>().AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return newCustomer;
        }

        public async Task UpdateAsync(Guid id, Customer customer)
        {
            var customerToUpdate = await GetByIdAsync(id);
            if(customerToUpdate == null)
                throw new CustomerNotFoundException(id);
            _dbContext.Set<Customer>().Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await GetByIdAsync(id);
            _dbContext.Set<Customer>().Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}