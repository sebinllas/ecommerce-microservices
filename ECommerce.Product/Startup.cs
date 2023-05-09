namespace ECommerce.Product;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Product.Controllers;

public static class DependencyInjectionConfig
{
    public static IServiceProvider Configure()
    {
        // Create an instance of the service collection
        var services = new ServiceCollection();

        // Register the IProductRepository interface and its implementation
        services.AddScoped<IProductRepository, ProductRepository>();

        // Register the ProductController class
        services.AddScoped<ProductController>();

        // Build the service provider
        return services.BuildServiceProvider();
    }
}