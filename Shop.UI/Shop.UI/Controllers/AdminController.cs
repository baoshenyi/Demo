using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.UI.Controllers
{
    //https://www.youtube.com/watch?v=YzryhsY6Kss&list=PLOeFnOV9YBa50nT3fEs0yzgMmK1MRKw3j&index=10
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDBContext _context;
        public AdminController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet("products")]
        public async Task<IEnumerable<ProductViewModel>> GetProducts() 
        {
            return await new GetProducts(_context).Do();
        }
        [HttpGet("products/{Id}")]
        public IActionResult GetProduct(int Id)
        {
            return Ok(new GetProduct(_context).Do(Id));
        }
        [HttpPost("products")]
        public IActionResult CreateProducts(ProductViewModel vm)
        {
            return Ok(new CreateProduct(_context).Do(vm));
        }
        [HttpDelete("products/{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            return Ok(new DeleteProduct(_context).Do(Id));
        }
        [HttpPut("products")]
        public IActionResult UpdateProduct(ProductViewModel vm)
        {
            return Ok(new UpdateProduct(_context).Do(vm));
        }
    }
}
