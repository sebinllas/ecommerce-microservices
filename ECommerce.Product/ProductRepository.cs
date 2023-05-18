using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Product;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;
    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<Product>().FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Set<Product>().ToListAsync();
    }

    public async Task<EntityEntry<Product>> AddAsync(Product product)
    {
        var newProduct = await _dbContext.Set<Product>().AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return newProduct;
    }

    public async Task UpdateAsync(Guid id, Product product)
    {
        var productToUpdate = await GetByIdAsync(id);
        _dbContext.Set<Product>().Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        _dbContext.Set<Product>().Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}