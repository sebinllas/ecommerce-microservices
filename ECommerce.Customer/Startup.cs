namespace ECommerce.Customer;

using Microsoft.Extensions.DependencyInjection;
using ECommerce.Customer.Controllers;

public static class DependencyInjectionConfig
{
    public static IServiceProvider Configure()
    {
        // Create an instance of the service collection
        var services = new ServiceCollection();

        // Register the ICustomerRepository interface and its implementation
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        // Register the CustomerController class
        services.AddScoped<CustomerController>();

        // Build the service provider
        return services.BuildServiceProvider();
    }
}