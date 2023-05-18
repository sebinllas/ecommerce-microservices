using ECommerce.Customer.DTOs;
using ECommerce.Customer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace ECommerce.Customer.Helpers;

public class MongoDbService{

    private readonly IMongoCollection<AuditCreateCustomer> _auditCreateCustomer;
    private readonly IMongoCollection<AuditUpdateCustomer> _auditUpdateCustomer;
    private readonly IMongoCollection<AuditDeleteCustomer> _auditDeleteCustomer;
    
    public MongoDbService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _auditCreateCustomer = database.GetCollection<AuditCreateCustomer>("create");
        _auditUpdateCustomer = database.GetCollection<AuditUpdateCustomer>("update");
        _auditDeleteCustomer = database.GetCollection<AuditDeleteCustomer>("delete");
    }

    public void RegisterCreateAsync(AuditCreateCustomer auditCreateCustomer)
    {
        _auditCreateCustomer.InsertOneAsync(auditCreateCustomer);
    }

    public void RegisterUpdateAsync(AuditUpdateCustomer auditUpdateCustomer)
    {
        _auditUpdateCustomer.InsertOneAsync(auditUpdateCustomer);
    }

    public void RegisterDeleteAsync(AuditDeleteCustomer auditDeleteCustomer)
    {
        _auditDeleteCustomer.InsertOneAsync(auditDeleteCustomer);
    }
}