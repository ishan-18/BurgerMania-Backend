using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.CartItem;
using api.Dto.User;

namespace api.Dto.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<CartItemDto>? Items { get; set; } = new List<CartItemDto>();
        public int UserId { get; set; }
        public UserDto? User { get; set; }
    }
}