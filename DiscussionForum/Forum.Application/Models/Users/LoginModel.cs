using Forum.Application.Interfaces.IModels.IUsers;

namespace Forum.Application.Models.Users
{
    public class LoginModel : ILogInModel
    {
        public string Password { get; set; }
        public string Username { get ; set ; }
    }
}
