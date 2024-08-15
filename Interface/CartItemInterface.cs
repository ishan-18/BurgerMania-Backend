using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface CartItemInterface
    {

        // Cart Id
        Task<CartItem> GetAllAsync(int id);
        // CartItem Id
        Task<CartItem> GetByIdAsync(int id);
    }
}