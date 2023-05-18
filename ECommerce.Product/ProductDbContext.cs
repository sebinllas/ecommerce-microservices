namespace ECommerce.Product;

using Microsoft.EntityFrameworkCore;

public class ProductDbContext : DbContext
{
    private readonly IConfiguration Configuration;

    public ProductDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products { get; set; }
}