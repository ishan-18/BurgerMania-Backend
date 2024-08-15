using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.User;
using api.Interface;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userRepo;
        public readonly ITokenService _tokenService;

        public UserController(UserInterface userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await _userRepo.GetAllAsync();
                var userModel = user.Select(u => u.toUserDto());
                return Ok(userModel);
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
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user.toUserDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto user)
        {
            try
            {
                var userDto = user.toCreateUserDto();
                await _userRepo.CreateAsync(userDto);
                var token = _tokenService.GenerateToken(userDto.Username);
                return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, new { Token = token, user = userDto.toUserDto() });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            try
            {
                var user = await _userRepo.LoginAsync(userDto.Username);
                if(user?.Username != userDto.Username || user.Password != userDto.Password)
                {
                    return Unauthorized("Invalid username or password.");
                }

                var token = _tokenService.GenerateToken(user.Username);
                return Ok(new { Token = token, User = user.toUserDto() });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserUpdateDto userDto)
        {
            try
            {
                var user = await _userRepo.UpdateAsync(id, userDto);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user.toUserDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var user = await _userRepo.DeleteAsync(id);
                if (user == null)
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