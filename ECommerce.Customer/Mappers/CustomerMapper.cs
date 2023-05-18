using ECommerce.Customer.DTOs;

namespace ECommerce.Customer.Mappers;

public static class CustomerMapper
{
    public static Customer toCustomer(this CustomerCreateDTO customerCreateDto)
    {
        return new Customer
        {
            FullName = customerCreateDto.FullName,
            EmailAddress = customerCreateDto.EmailAddress,
            PhoneNumber = customerCreateDto.PhoneNumber,
            Address = customerCreateDto.Address
        };
    }
}