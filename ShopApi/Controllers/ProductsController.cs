using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [ApiController]    
    [Route("/api/Products")]
    public class ProductsController : ControllerBase
    {
        public readonly ShopDBContext _context;
        public ProductsController(ShopDBContext context)
        {
            _context = context;

         }        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getListProductAsync(CancellationToken token)
        {
            
            var products = await _context.Product.ToArrayAsync( token);
            if( products == null)
            {
                return NoContent();
            }

            return Ok(products);

        }
        [HttpGet("{id}")]
        public ActionResult<Product> getProduct(int id)
        {
            var products = _context.Product.Where( x => x.Id == id).FirstOrDefault();
            if (products == null)
            {
                return BadRequest("Produit vide");
            }
            return Ok(products);

        }




    }
}
