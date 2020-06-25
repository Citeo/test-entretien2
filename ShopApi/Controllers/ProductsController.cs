using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [ApiController]    
    [Route("api/[controller]/v1")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDBContext _dBContext;
        public ProductsController(ShopDBContext shopDBContext)
        {
            _dBContext = shopDBContext;
        }        

        [HttpGet]
        //[Route("")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _dBContext.Product.ToArrayAsync();

            if (!products.Any())
            {
                return NoContent();
            }

            return new JsonResult(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _dBContext.Product.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NoContent();
            }

            return new JsonResult(product);
        }

        [HttpPost]
        //[Route("{id}")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                product.CreationDate = DateTime.Now;
                _dBContext.Product.Add(product);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // log etc...
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



            
            return new JsonResult(product);
        }

        [HttpPut]
        
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try

            {
                product.UpdateDate = DateTime.Now;
                _dBContext.Product.Update(product);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // log etc...
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return new JsonResult(product);
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetCustomerOrders()
        {
            var result = await _dBContext.Customer
                                    .Include(o => o.Order)
                                    .ThenInclude(o => o.OrderItem)
                                    .ThenInclude(p => p.Product)
                                    .Select(customer => new
                                    {
                                        Email = customer.Email,
                                        Total = customer.Order.Select(o => o.OrderItem.Select(p => p.Product.Price).Sum())
                                    })
                                    .ToArrayAsync();


            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
