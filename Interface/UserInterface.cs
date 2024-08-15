using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.User;
using api.Models;

namespace api.Interface
{
    public interface UserInterface
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User?> LoginAsync(string username);
        Task<User?> UpdateAsync(int id, UserUpdateDto user);
        Task<User?> DeleteAsync(int id);
    }
}