namespace ECommerce.Customer.Models;

public class UserRequestData
{
    public string Email { get;}
    public string IpAddress { get; }
    
    public UserRequestData(string Email, string ipAddress)
    {
        this.Email = Email;
        this.IpAddress = ipAddress;
    }
}