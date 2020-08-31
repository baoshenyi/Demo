﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.ProductsAdmin;
using Shop.Application.ViewModels;
using Shop.Database;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDBContext _context;


        [BindProperty]//indicate main model
        public ProductViewModel Product { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            var products = await new GetProducts(_context).Do();
        }

        public async Task<IActionResult> OnPost()
        {
            //with bindproperty, we get product object
            await new CreateProduct(_context).Do(Product);
            return RedirectToPage("index");
        }
    }
}
