using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Order;
using api.Models;

namespace api.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto toOrderDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CartId = order.CartId,
                Cart = order?.Cart?.toCartDto(),
                TotalPrice = order.TotalPrice
            };
        }

        public static Order toOrderCreateDto(this OrderCreateDto order)
        {
            return new Order
            {
                CartId = order.CartId,
            };
        }
    }
}