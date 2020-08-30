using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
    public class CreateProduct
    {
        public ApplicationDBContext  _context { get; set; }
        public CreateProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task Do(string Name, string Description, decimal Price)
        {
            _context.Products.Add(new Product
            {
                Name = Name,
                Desription = Description,
                Price = Price
            });
            _context.SaveChanges();
        }
    }
}
