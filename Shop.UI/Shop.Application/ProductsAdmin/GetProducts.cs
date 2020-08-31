﻿using Shop.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class GetProducts
    {
        private ApplicationDBContext _context;
        public GetProducts(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductViewModel>> Do() =>
            _context.Products.ToList().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
    }
}
