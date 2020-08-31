using Shop.Application.ViewModels;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class GetProduct
    {
        private ApplicationDBContext _context;
        public GetProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ProductViewModel> Do(int Id) =>
            _context.Products.Where(x=> x.Id == Id).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).FirstOrDefault();
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
    }
}
