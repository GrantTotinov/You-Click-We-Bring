using System;
using System.Collections.Generic;
using System.Text;

namespace GrantFoods6.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
    }
}
