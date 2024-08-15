using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.CartItem;
using api.Models;

namespace api.Mappers
{
    public static class CartItemMapper
    {
        public static CartItemDto toCartItemDto(this CartItem cartItem)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                BurgerId = cartItem.BurgerId,
                Quantity = cartItem.Quantity,
                CartId = cartItem.CartId,
                Burger = cartItem?.Burger?.toBurgerDto(),
            };
        }

        public static CartItem toCartItemCreateDto(this CartItemCreateDto cartItem)
        {
            return new CartItem
            {
                BurgerId = cartItem.BurgerId,
                Quantity = cartItem.Quantity
            };
        }
    }
}