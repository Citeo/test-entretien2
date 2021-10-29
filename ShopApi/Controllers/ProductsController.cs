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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDBContext _dbContext;
        public ProductsController(ShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("Lister")]
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            try
            {
                var ListProducts = _dbContext
                        .Product.ToList();
                return ListProducts;
            }
            catch (Exception)
            {
                return BadRequest("ops Error !!");
            }
            return BadRequest("ops Error !!");
        }


        //[HttpPut("{idProduct}")]
        //public ActionResult<Product> Get(int idProduct)
        //{
        //    //if(idProduct==null)
        //    try
        //    {
        //        var Product = _dbContext
        //                .Product.Where(p=>p.Id==idProduct).FirstOrDefault();
        //        return Product;
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("ops Error !!");
        //    }
        //    return BadRequest("ops Error !!");
        //}

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            //if(idProduct==null)
            try
            {
                var Product = _dbContext
                        .Product.Where(p => p.Id == id).FirstOrDefault();
                return Product;
            }
            catch (Exception)
            {
                return BadRequest("ops Error !!");
            }
            return BadRequest("ops Error !!");
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id,Product product)
        {

            //try
            //{
            //    _dbContext.Product.Add(product);
            //    _dbContext.SaveChanges();
            //    return Ok("Product add well");
            //}
            //catch (Exception)
            //{
            //    return BadRequest("ops Error !!");
            //}
            //return BadRequest("ops Error !!");
        }

    }
}
