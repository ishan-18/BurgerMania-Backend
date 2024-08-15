using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Cart;
using api.Models;

namespace api.Mappers
{
    public static class CartMapper
    {
        public static CartDto toCartDto(this Cart cart)
        {
            return new CartDto
            {
                Id = cart.Id,
                Items = cart?.Items?.Select(i => i.toCartItemDto()).ToList(),
                User = cart?.User?.toUserDto(),
                UserId = cart.UserId,
            };
        }

        public static CartDto toCartCreateDto(this CartCreateDto cart)
        {
            return new CartDto
            {
                Items = cart?.Items?.Select(i => i).ToList(),
                User = cart?.User,
                UserId = cart.UserId,
            };
        }
    }
}