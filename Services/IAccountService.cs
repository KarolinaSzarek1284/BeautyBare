using BeautyBareAPI.Models;

namespace BeautyBareAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserModel dto);
        string GenerateJwt(LoginModel dto);
    }
}
