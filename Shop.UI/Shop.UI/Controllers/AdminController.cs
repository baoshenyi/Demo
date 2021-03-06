﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.UI.Controllers
{
    //https://www.youtube.com/watch?v=YzryhsY6Kss&list=PLOeFnOV9YBa50nT3fEs0yzgMmK1MRKw3j&index=10
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDBContext _context;
        public AdminController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(_context).Do());

        [HttpGet("products/{Id}")]
        public IActionResult GetProduct(int Id) => Ok(new GetProduct(_context).Do(Id));

        [HttpPost("product")]
        //[FromBody] is required sicne post passes json object (complext type) to the function
        public IActionResult CreateProduct([FromBody] Request request) => Ok(new CreateProduct(_context).Do(request));


        [HttpDelete("products/{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            return Ok(new DeleteProduct(_context).Do(Id));
        }
        [HttpPut("product")]
        public IActionResult UpdateProduct([FromBody] Request request) => 
            Ok(new UpdateProduct(_context).Do(request));

        //Example to use [FromUri] to pass complext type; (tuples c#?)
        //public class GeoPoint
        //{
        //    public double Latitude { get; set; }
        //    public double Longitude { get; set; }
        //}

        //[RoutePrefix("api/Values")]
        //public ValuesController : ApiController
        //{
        //[Route("{Latitude}/{Longitude}")]
        //public HttpResponseMessage Get([FromUri] GeoPoint location) { ... }
        //http://localhost/api/values/47.678558/-122.130989
        //Caution: Will not work!    
        //public HttpResponseMessage Post([FromBody] int id, [FromBody] string name) { ... }
    }
}
