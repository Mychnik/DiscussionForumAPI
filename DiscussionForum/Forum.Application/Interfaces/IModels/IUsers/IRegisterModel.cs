namespace Forum.Application.Interfaces.IModels.IUsers
{
    public interface IRegisterModel
    {
        string ConfirmPassword { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}
