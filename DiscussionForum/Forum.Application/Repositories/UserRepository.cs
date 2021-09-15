using AutoMapper;
using Forum.Application.Exceptions;
using Forum.Application.Helpers;
using Forum.Application.Interfaces;
using Forum.Application.Interfaces.IModels.IUsers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Repositories
{
   public class UserRepository : IUser
    {
        private readonly UserManager<IdentityUser> _uManager;
        private readonly SignInManager<IdentityUser> _sInManager;
        private readonly IMapper _mapper;
       // private readonly IHttpContextAccessor _httpcon;
        public UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMapper mapper )
        {
            _uManager = userManager;
            _sInManager = signInManager;
            _mapper = mapper;
            //_httpcon = httpcon; IHttpContextAccessor httpcon
        }

        public async Task LogInUser(ILogInModel model)
        {
            var user = await _uManager.FindByNameAsync(model.Username);
            if (user == null) throw new UserNotExistingException("Nie znaleziono takiego użytkownika");

            var signInResult = await _sInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (!signInResult.Succeeded) throw new SignInFailedException("Nie udało się zalogować");

            //var info = _mapper.Map<IUserInfo>(user);
            //return info;
        }

        public async Task<string> LogOutUser()
        {
            await _sInManager.SignOutAsync();
            string result = "logout";
            return result;
        }

        public async Task<IdentityResult> RegisterUser(IRegisterModel model)
        {
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _uManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await _uManager.FindByNameAsync(model.UserName); 
                await _uManager.AddToRoleAsync(user, IdentityConstantHelper.UsersRoleConstans);
            }
            return result;
        }
    }
}
