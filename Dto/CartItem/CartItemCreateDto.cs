using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.CartItem
{
    public class CartItemCreateDto
    {
        public int BurgerId { get; set; }
        public int Quantity { get; set; }
    }
}