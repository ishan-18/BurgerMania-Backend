using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Burger;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/burger")]
    [ApiController]
    public class BurgerController : ControllerBase
    {
        private readonly BurgerInterface _burgerRepo;
        public BurgerController(BurgerInterface burgerRepo)
        {
            _burgerRepo = burgerRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var burger = await _burgerRepo.GetAllAsync();
                var burgerModel = burger.Select(b => b.toBurgerDto());
                return Ok(new {Burger = burgerModel, Total = burgerModel.Count()});
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
                var burger = await _burgerRepo.GetByIdAsync(id);
                if (burger == null)
                {
                    return NotFound();
                }

                return Ok(burger.toBurgerDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] BurgerCreateDto burgerDto)
        {
            try
            {
                var burger = burgerDto.toBurgerCreateDto();
                await _burgerRepo.CreateAsync(burger);
                return CreatedAtAction(nameof(GetById), new { id = burger.Id }, burger.toBurgerDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BurgerUpdateDto burgerDto)
        {
            try
            {
                var burger = await _burgerRepo.UpdateAsync(id, burgerDto);
                if (burger == null)
                {
                    return NotFound();
                }
                return Ok(burger.toBurgerDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var burger = await _burgerRepo.DeleteAsync(id);
                if (burger == null)
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