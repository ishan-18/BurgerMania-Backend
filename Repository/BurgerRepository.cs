using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Burger;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BurgerRepository : BurgerInterface
    {
        private readonly ApplicationDBContext _context;
        public BurgerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<Burger> CreateAsync(Burger burger)
        {
            if (burger.BurgerName.Trim() == "" || burger.Price == 0 || burger?.BurgerCategory?.Trim() == "" || burger?.BurgerDesc?.Trim() == "" || burger?.BurgerImage?.Trim() == "")
            {
                throw new ArgumentException("Please Enter all the fields...");
            } 
            await _context.Burgers.AddAsync(burger);
            await _context.SaveChangesAsync();
            return burger;
        }

        public async Task<Burger?> DeleteAsync(int id)
        {
            var burger = await _context.Burgers.FirstOrDefaultAsync(b => b.Id == id);
            if(burger == null) 
            {
                return null;
            }
            _context.Burgers.Remove(burger);
            await _context.SaveChangesAsync();
            return burger;
        }

        public Task<List<Burger>> GetAllAsync()
        {
            return _context.Burgers.ToListAsync();
        }

        public async Task<Burger?> GetByIdAsync(int id)
        {
            var burger = await _context.Burgers.FirstOrDefaultAsync(b => b.Id == id);
            if(burger == null)
            {
                return null;
            }
            return burger;
        }

        public async Task<Burger?> UpdateAsync(int id, BurgerUpdateDto burgerDto)
        {
            if (burgerDto.BurgerName.Trim() == "" || burgerDto.Price == 0 || burgerDto?.BurgerCategory?.Trim() == "" || burgerDto?.BurgerDesc?.Trim() == "" || burgerDto?.BurgerImage?.Trim() == "")
            {
                throw new ArgumentException("Please Enter all the fields...");
            }
            var burger = await _context.Burgers.FirstOrDefaultAsync(b => b.Id == id);
            if(burger == null)
            {
                return null;
            }
            burger.BurgerName = burgerDto.BurgerName;
            burger.Price = burgerDto.Price;
            burger.BurgerDesc = burgerDto.BurgerDesc;
            burger.BurgerImage = burgerDto.BurgerImage;
            burger.BurgerCategory = burgerDto.BurgerCategory;

            await _context.SaveChangesAsync();
            return burger;
        }
    }
}