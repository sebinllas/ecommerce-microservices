using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Code = "P0001",
                Name = "Basic white t-shirt",
                QuantityInStock = 15,
                UnitPrice = 125000
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Code = "P0002",
                Name = "Black sweatshirt with zip",
                QuantityInStock = 25,
                UnitPrice = 135000
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Code = "P0003",
                Name = "Oversized green printed t-shirt ",
                QuantityInStock = 20,
                UnitPrice = 115000
            });
        }
        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(products);
        }
    }
}