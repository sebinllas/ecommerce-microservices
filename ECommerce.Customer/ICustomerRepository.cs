using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Customer
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers();
    }
}