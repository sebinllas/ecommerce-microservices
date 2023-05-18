using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllCustomers()
        {
            return await _productRepository.GetAllAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetCustomerById(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> AddCustomer(Product product)
        {
            var newProduct = await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetCustomerById), new { id = newProduct.Entity.Id }, newProduct.Entity);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(Guid id, Product product)
        {
            await _productRepository.UpdateAsync(id, product);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
        
    }
}