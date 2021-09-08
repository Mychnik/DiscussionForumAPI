using Forum.Application.Interfaces.IModels.IUsers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Forum.Application.Interfaces
{
    public  interface IUser
    {
        Task<IdentityResult> RegisterUser(IRegisterModel model);
        Task LogInUser(ILogInModel model);
        Task<string> LogOutUser();

    }
}
