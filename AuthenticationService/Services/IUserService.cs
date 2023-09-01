using AuthenticationService.Entities;

namespace AuthenticationService.Services
{
    public interface IUserService
    {
        bool LoginUser(User user);
        bool RegisterUser(User user);
    }
}
