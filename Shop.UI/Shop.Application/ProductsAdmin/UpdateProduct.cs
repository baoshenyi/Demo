using Shop.Application.ViewModels;
using Shop.Database;
using System;
using System.Collections.Generic;
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
            await _context.SaveChangesAsync();
        }
    }
}
