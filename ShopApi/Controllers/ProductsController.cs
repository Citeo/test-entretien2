using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("Products")]
    [ApiController]    
    public class ProductsController : ControllerBase
    {
        private ShopDBContext _context;

        public ProductsController(ShopDBContext context)
        {
            _context = context;
        }     
        
        [HttpGet]
        public Task<List<Product>> Get()
        {
            return _context.Product.ToListAsync();
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var product = await _context.Product.FirstOrDefaultAsync(product => product.Id == id);
            var product = await _context.Product.FindAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
