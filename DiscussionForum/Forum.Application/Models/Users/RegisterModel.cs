using Forum.Application.Interfaces.IModels.IUsers;

namespace Forum.Application.Models.Users
{
    public class RegisterModel : IRegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        
    }
}
