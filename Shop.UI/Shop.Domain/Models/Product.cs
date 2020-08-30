using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        //No type was specified for the decimal column 'Price' on entity type 'Product'. 
        //This will cause values to be silently truncated
        public decimal Price { get; set; }
    }
}
