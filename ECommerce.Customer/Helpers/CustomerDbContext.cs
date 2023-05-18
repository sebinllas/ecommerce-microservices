namespace ECommerce.Customer.Helpers;

using Microsoft.EntityFrameworkCore;
using ECommerce.Customer;

public class CustomerDbContext : DbContext
{
    private readonly IConfiguration Configuration;

    public CustomerDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Customer> Customers { get; set; }
}