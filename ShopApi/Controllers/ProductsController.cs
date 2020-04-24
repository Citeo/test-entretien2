using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ShopApi.Models;

using System;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDBContext _dbContext;

        public ProductsController(ShopDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<ActionResult> GetAllAsync()
        {
            var entities = await _dbContext.Product.ToListAsync();
            return Ok(entities);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult> GetByIdAsync(int productId)
        {
            var product = await _dbContext.Product.FindAsync(productId);

            if (product == null) return NotFound();


            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Product product)
        {
            product.CreationDate = DateTime.Now;
            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();


            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Product product)
        {
            var productToUpdate = await _dbContext.Product.FindAsync(product.Id);

            if (product == null) return NotFound();

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Stock = product.Stock;

            await _dbContext.SaveChangesAsync();

            return Ok(product);
        }
    }
}
