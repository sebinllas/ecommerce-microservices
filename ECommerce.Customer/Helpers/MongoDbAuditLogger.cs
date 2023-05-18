using ECommerce.Customer.DTOs;
using ECommerce.Customer.Models;

namespace ECommerce.Customer.Helpers;

public class MongoDbAuditLogger : IAuditLogger
{
    private readonly UserDataAccessor _userDataAccessor;
    private readonly MongoDbService _mongoDbService;

    public MongoDbAuditLogger(UserDataAccessor userDataAccessor, MongoDbService mongoDbService)
    {
        _userDataAccessor = userDataAccessor;
        _mongoDbService = mongoDbService;
    }

    public void LogCreate(CustomerCreateDTO customer)
    {
        _mongoDbService.RegisterCreateAsync(
            new AuditCreateCustomer(_userDataAccessor.GetUserData(), customer)
        );
    }

    public void LogUpdate(Customer oldCustomer, Customer newCustomer)
    {
        _mongoDbService.RegisterUpdateAsync(
            new AuditUpdateCustomer(_userDataAccessor.GetUserData(), oldCustomer, newCustomer)
        );
    }

    public void LogDelete(Customer customer)
    {
        _mongoDbService.RegisterDeleteAsync(
            new AuditDeleteCustomer(_userDataAccessor.GetUserData(), customer)
        );
    }
}