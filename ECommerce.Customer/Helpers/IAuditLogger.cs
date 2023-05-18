using ECommerce.Customer.DTOs;

namespace ECommerce.Customer.Helpers;

public interface IAuditLogger
{
    public void LogCreate(CustomerCreateDTO customer);
    public void LogUpdate(Customer oldCustomer, Customer newCustomer);
    public void LogDelete(Customer customer);
}