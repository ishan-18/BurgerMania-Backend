using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CartRepository : CartInterface
    {
        private readonly ApplicationDBContext _context;
        public CartRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Cart?> AddItemsAsync(int id, CartItem cartItemDto)
        {
            var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == id);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            var burger = await _context.Burgers.FirstOrDefaultAsync(b => b.Id == cartItemDto.BurgerId);
            if (burger == null)
            {
                return null;
            }

            CartItem cartItem = new CartItem()
            {
                Id = cartItemDto.Id,
                BurgerId = cartItemDto.BurgerId,
                Burger = burger,
                Quantity = cartItemDto.Quantity,
                CartId = cart.Id
            };

            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == id);
            return cart;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts.Include(c => c.Items).ThenInclude(i => i.Burger).Include(u => u.User).FirstOrDefaultAsync(c => c.UserId == id);
            if (cart == null)
            {
                return null;
            }
            return cart;
        }

        public async Task<CartItem?> RemoveItemsAsync(int id)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.Id == id);
            if(cartItem == null)
            {
                return null;
            }
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }
    }
}