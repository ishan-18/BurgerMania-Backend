using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; } = string.Empty;
        public string? MobileNumber { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? UserRole { get; set; } = string.Empty;
    }
}