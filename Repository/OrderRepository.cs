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
    public class OrderRepository : OrderInterface
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Order> Create(Order order)
        {
            var cart = await _context.Carts
                .Include(u => u.User)
                .Include(c => c.Items)
                .ThenInclude(i => i.Burger)
                .FirstOrDefaultAsync(c => c.Id == order.CartId);

            if (cart == null)
            {
                return null;
            }

            var totalPrice = cart.Items.Sum(item => item.Burger.Price * item.Quantity);
            order.TotalPrice = totalPrice;
            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.Cart).ThenInclude(c => c.Items).ThenInclude(i => i.Burger).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.Cart).ThenInclude(c => c.Items).ThenInclude(i => i.Burger).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return null;
            }
            return order;
        }
    }
}