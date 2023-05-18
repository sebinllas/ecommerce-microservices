using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Customer
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<List<Customer>> GetAllAsync();
        Task<EntityEntry<Customer>> AddAsync(Customer customer);
        Task UpdateAsync(Guid id, Customer customer);
        Task DeleteAsync(Guid id);
    }
}