using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Burger;
using api.Models;

namespace api.Interface
{
    public interface BurgerInterface
    {
        Task<List<Burger>> GetAllAsync();
        Task<Burger?> GetByIdAsync(int id);
        Task<Burger> CreateAsync(Burger burger);
        Task<Burger?> UpdateAsync(int id, BurgerUpdateDto burger);
        Task<Burger?> DeleteAsync(int id);
    }
}