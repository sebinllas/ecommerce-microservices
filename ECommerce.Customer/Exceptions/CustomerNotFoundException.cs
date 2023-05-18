namespace ECommerce.Customer.Exceptions;

public class CustomerNotFoundException: Exception
{
    public CustomerNotFoundException(string Message) : base(Message)
    {
    }

    public CustomerNotFoundException(Guid id) : base($"Customer with id {id} was not found")
    {
    }
}