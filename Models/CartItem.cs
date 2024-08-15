using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public Burger? Burger { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}