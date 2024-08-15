using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Cart;
using api.Dto.CartItem;

namespace api.Dto.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartDto? Cart { get; set; }
        public decimal TotalPrice { get; set; }
    }
}