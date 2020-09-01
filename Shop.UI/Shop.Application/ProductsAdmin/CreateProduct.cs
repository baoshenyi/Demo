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
        public async Task<int> Do(ProductViewModel productVM)
        {
            _context.Products.Add(new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = decimal.Parse(productVM.Price, NumberStyles.Currency)
            });
            return await  _context.SaveChangesAsync();
        }
    }
}
