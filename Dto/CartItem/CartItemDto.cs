using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Burger;

namespace api.Dto.CartItem
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public BurgerDto? Burger { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}