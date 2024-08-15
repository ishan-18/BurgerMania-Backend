using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface CartInterface
    {
        Task<Cart?> GetByIdAsync(int id);
        Task<Cart?> AddItemsAsync(int id, CartItem cart);
        Task<CartItem?> RemoveItemsAsync(int id);
    }
}