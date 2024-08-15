using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Order;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderInterface _orderRepo;

        public OrderController(OrderInterface orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var order = await _orderRepo.GetAllAsync();
                var orderModel = order.Select(o => o.toOrderDto());
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var order = await _orderRepo.GetByIdAsync(id);
                if(order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateDto orderDto)
        {
            try
            {
                var order = orderDto.toOrderCreateDto();
                await _orderRepo.Create(order);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}