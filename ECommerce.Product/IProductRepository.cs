using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Product
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task<EntityEntry<Product>> AddAsync(Product product);
        Task UpdateAsync(Guid id, Product product);
        Task DeleteAsync(Guid id);

    }
}