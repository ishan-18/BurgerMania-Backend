using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Burger
    {
        public int Id { get; set; }
        public string BurgerName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? BurgerDesc { get; set; } = string.Empty;
        public string? BurgerImage { get; set; } = string.Empty;
        public string? BurgerCategory { get; set; } = string.Empty;
    }
}