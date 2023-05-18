using ECommerce.Customer.DTOs;
using ECommerce.Customer.Exceptions;
using ECommerce.Customer.Helpers;
using ECommerce.Customer.Mappers;
using ECommerce.Customer.Models;

namespace ECommerce.Customer.Services;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IAuditLogger _auditLogger;
    private readonly UserDataAccessor _userDataAccessor;

    public CustomerService(ICustomerRepository customerRepository, IAuditLogger auditLogger, UserDataAccessor userDataAccessor)
    {
        _customerRepository = customerRepository;
        _auditLogger = auditLogger;
        _userDataAccessor = userDataAccessor;
        
    }

    public async Task<Customer> GetByIdAsync(Guid id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer> AddAsync(CustomerCreateDTO customer)
    {
        _auditLogger.LogCreate(customer);
        return _customerRepository.AddAsync(customer.toCustomer()).Result.Entity;
    }

    public async Task UpdateAsync(Guid id, Customer customer)
    {   
        _auditLogger.LogUpdate(await _customerRepository.GetByIdAsync(id), customer);
        await _customerRepository.UpdateAsync(id, customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            _auditLogger.LogDelete(await _customerRepository.GetByIdAsync(id));
            await _customerRepository.DeleteAsync(id);
        }
        catch (ArgumentNullException e)
        {
            throw new CustomerNotFoundException(id);
        }
    }
}