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

        public async Task Do(ProductViewModel productVM)
        {
            var product = _context.Products.Where(x => x.Id == productVM.Id).FirstOrDefault();
            if (product != null)
            {
                product.Name = productVM.Name;
                product.Description = productVM.Description;
                product.Price = decimal.Parse(productVM.Price);
                await _context.SaveChangesAsync();
            }
        }
    }
}
