using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Username { get; set; } = string.Empty;
        public string? MobileNumber { get; set; } = string.Empty;
        public string? UserRole { get; set; } = string.Empty;
    }
}