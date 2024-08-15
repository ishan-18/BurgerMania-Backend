using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.CartItem;
using api.Interface;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartInterface _cartRepo;

        public CartItemController(CartInterface cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var cart = await _cartRepo.GetByIdAsync(id);
                if(cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("add/{id}")]
        public async Task<IActionResult> AddItems([FromRoute] int id, [FromBody] CartItemCreateDto cartItem)
        {
            try
            {
                var cartDto = cartItem.toCartItemCreateDto();
                var cart = await _cartRepo.AddItemsAsync(id, cartDto);
                if(cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveItems([FromRoute] int id)
        {
            try
            {
                var cart = await _cartRepo.RemoveItemsAsync(id);
                if(cart == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}