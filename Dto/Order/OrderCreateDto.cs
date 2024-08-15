using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Cart;
using api.Dto.CartItem;

namespace api.Dto.Order
{
    public class OrderCreateDto
    {
        public int CartId { get; set; }
    }
}