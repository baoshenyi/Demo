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

        public async Task Do(ProductViewModel productVM)
        {
            _context.Products.Add(new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = decimal.Parse(productVM.Price, NumberStyles.Currency)
            });
            await _context.SaveChangesAsync();
        }
    }
}
