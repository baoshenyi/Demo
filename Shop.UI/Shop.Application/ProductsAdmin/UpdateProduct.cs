using Shop.Application.ViewModels;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        public ApplicationDBContext _context { get; set; }
        public UpdateProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = decimal.Parse(request.Price);
                await _context.SaveChangesAsync();
            }
            return new Response {
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
