using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class CreateProduct
    {
        public ApplicationDBContext  _context { get; set; }
        public CreateProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        //without await, _context.SaveChangesAsync() will not work
        public async Task<Response> Do(Request reqeest)
        {
            var product = new Product
            {
                Name = reqeest.Name,
                Description = reqeest.Description,
                Price = decimal.Parse(reqeest.Price, NumberStyles.Currency)
            };
            _context.Products.Add(product);
            await  _context.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
    }
}
