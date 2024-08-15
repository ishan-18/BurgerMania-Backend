using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Burger
{
    public class BurgerUpdateDto
    {
        public string BurgerName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? BurgerDesc { get; set; } = string.Empty;
        public string? BurgerImage { get; set; } = string.Empty;
        public string? BurgerCategory { get; set; } = string.Empty;
    }
}