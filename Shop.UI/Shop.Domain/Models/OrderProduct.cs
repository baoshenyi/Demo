using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }//it will not show up in table
        public int OrderId { get; set; }
        public Order Order{ get; set; }//it will not show up in table
    }
}
