using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto toUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                MobileNumber = user.MobileNumber,
                Username = user.Username,
                UserRole = user.UserRole
            };
        }

        public static User toCreateUserDto(this UserCreateDto userDto)
        {
            return new User 
            {
                Username = userDto.Username,
                MobileNumber = userDto.MobileNumber,
                Password = userDto.Password,
                UserRole = userDto.UserRole
            };
        }

        public static User toUserLoginDto(this UserLoginDto userDto)
        {
            return new User 
            {
                Username = userDto.Username,
                Password = userDto.Password
            };
        }
    }
}