using AutoMapper;
using Forum.Application.Helpers;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.IUsers;
using Forum.Application.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = IdentityConstantHelper.UsersRoleConstans)]
    public class UserController : ControllerBase
    {
        private readonly IUser _uRepository;
        private readonly IMapper _mapper;

        public UserController(IUser userRepository, IMapper mapper)
        {
            _uRepository = userRepository;
            _mapper = mapper;
        }
        [HttpPost("register", Name = "Register")]
        [AllowAnonymous]
        public async Task<ActionResult<IdentityResult>> Register([FromBody] RegisterModel user)
        {
            var result = await _uRepository.RegisterUser(user);
            return Ok(result);
        }
        [HttpPost("login", Name = "LogIn")]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn([FromBody] LoginModel model)
        {
            try
            {
               
                await _uRepository.LogInUser(model);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.HResult == 400)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.Message);
                }
                throw;
            }
        }
        [HttpGet("logout", Name = "LogOut")]
        public async Task<ActionResult> LogOut()
        {
            var response = await _uRepository.LogOutUser();
            return Ok(response);
        }

    }
}
