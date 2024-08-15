using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using api.Data;
using api.Dto.User;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : UserInterface
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            if(user.Username == "" || user.Password == "" || user.MobileNumber == "" || user.UserRole == "")
            {
                throw new ArgumentException("Please Enter all the fields");
            }
            if(user.MobileNumber?.Length != 10 || !user.MobileNumber.All(char.IsDigit)) 
            {
                throw new ArgumentException("Mobile number should be exactly 10 characters long and must contain all digits.", nameof(user.MobileNumber));
            }
            await _context.Users.AddAsync(user);
            var cart = new Cart { UserId = user.Id, User = user, Items = [] };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> LoginAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);    
        }

        public async Task<User?> UpdateAsync(int id, UserUpdateDto userDto)
        {
            if(userDto.Username == "" || userDto.Password == "" || userDto.MobileNumber == "")
            {
                throw new ArgumentException("Please Enter all the fields");
            }
            if(userDto.MobileNumber?.Length != 10 || !userDto.MobileNumber.All(char.IsDigit)) 
            {
                throw new ArgumentException("Mobile number should be exactly 10 characters long and must contain all digits.", nameof(userDto.MobileNumber));
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }

            user.MobileNumber = userDto.MobileNumber;
            user.Username = userDto.Username;
            user.Password = userDto.Password;

            await _context.SaveChangesAsync();
            return user;
        }
    }
}