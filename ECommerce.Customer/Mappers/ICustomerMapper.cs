using ECommerce.Customer.DTOs;

namespace ECommerce.Customer.Mappers;

public interface ICustomerMapper
{
    public Customer toCustomer(CustomerCreateDTO customerCreateDto);
}