using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Products
{
    public class CreateProduct
    {
        public ApplicationDBContext  _context { get; set; }
        public CreateProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Do(int Id, string Name, string Description, decimal Price)
        {
            _context.Products.Add(new Product
            {
                Id = Id,
                Name = Name,
                Desription = Description,
                Price = Price
            });
            _context.SaveChanges();
        }
    }
}
