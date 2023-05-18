using System.Globalization;
using ECommerce.Customer.DTOs;

namespace ECommerce.Customer.Helpers;

public class BasicAuditLogger : IAuditLogger
{
    private readonly UserDataAccessor _userDataAccessor;

    public BasicAuditLogger(UserDataAccessor userDataAccessor)
    {
        _userDataAccessor = userDataAccessor;
    }

    public void LogCreate(CustomerCreateDTO customer)
    {
        Console.WriteLine(
            $"Created customer with email {customer.ToString()} " +
            $"by user with email {_userDataAccessor.GetUserData().Email} " +
            $"from IP {_userDataAccessor.GetUserData().IpAddress} at " +
            $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"
        );
    }

    public void LogUpdate(Customer oldCustomer, Customer newCustomer)
    {
        Console.WriteLine(
            $"Updated customer {oldCustomer.ToString()} to {newCustomer.ToString()}" +
            $"by user with email {_userDataAccessor.GetUserData().Email} " +
            $"from IP {_userDataAccessor.GetUserData().IpAddress} at " +
            $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"
        );
    }

    public void LogDelete(Customer customer)
    {
        Console.WriteLine(
            $"Deleted customer {customer.ToString()}" +
            $"by user with email {_userDataAccessor.GetUserData().Email} " +
            $"from IP {_userDataAccessor.GetUserData().IpAddress} at " +
            $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}"
        );
    }
}