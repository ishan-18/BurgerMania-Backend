using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Burger;
using api.Models;

namespace api.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerDto toBurgerDto(this Burger burger)
        {
            return new BurgerDto
            {
                Id = burger.Id,
                BurgerName = burger.BurgerName,
                Price = burger.Price,
                BurgerDesc = burger.BurgerDesc,
                BurgerImage = burger.BurgerImage,
                BurgerCategory = burger.BurgerCategory
            };
        }

        public static Burger toBurgerCreateDto(this BurgerCreateDto burger)
        {
            return new Burger
            {
                BurgerName = burger.BurgerName,
                Price = burger.Price,
                BurgerDesc = burger.BurgerDesc,
                BurgerImage = burger.BurgerImage,
                BurgerCategory = burger.BurgerCategory
            };
        }

        public static Burger toBurgerUpdateDto(this BurgerUpdateDto burger)
        {
            return new Burger
            {
                BurgerName = burger.BurgerName,
                Price = burger.Price,
                BurgerDesc = burger.BurgerDesc,
                BurgerImage = burger.BurgerImage,
                BurgerCategory = burger.BurgerCategory
            };
        }
    }
}