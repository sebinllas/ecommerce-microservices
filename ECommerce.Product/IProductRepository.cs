using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Product
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
    }
}