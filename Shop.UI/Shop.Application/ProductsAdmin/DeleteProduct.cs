using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class DeleteProduct
    {
        public ApplicationDBContext _context { get; set; }
        public DeleteProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task Do(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
