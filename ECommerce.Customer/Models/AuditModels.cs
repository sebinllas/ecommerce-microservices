using ECommerce.Customer.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Customer.Models;

public class AuditCreateCustomer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public UserRequestData UserRequestData { get; set; }
    public CustomerCreateDTO Customer { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;


    public AuditCreateCustomer(UserRequestData userRequestData, CustomerCreateDTO customer)
    {
        UserRequestData = userRequestData;
        Customer = customer;
    }
}

public class AuditUpdateCustomer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public UserRequestData UserRequestData { get; set; }
    public Customer OldCustomer { get; set; }
    public Customer NewCustomer { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;


    public AuditUpdateCustomer(UserRequestData userRequestData, Customer oldCustomer, Customer newCustomer)
    {
        UserRequestData = userRequestData;
        OldCustomer = oldCustomer;
        NewCustomer = newCustomer;
    }
}

public class AuditDeleteCustomer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public UserRequestData UserRequestData { get; set; }
    public Customer Customer { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public AuditDeleteCustomer(UserRequestData userRequestData, Customer customer)
    {
        UserRequestData = userRequestData;
        Customer = customer;
    }
}