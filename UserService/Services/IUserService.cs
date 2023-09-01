using UserService.Entities;

namespace UserService.Services
{
    public interface IUserService
    {
        User RegisterUser(User user);
        bool UpdateUser(string userId, User user);
        bool DeleteUser(string userId);
        User GetUserById(string userId);
        List<User> GetUser();
    }
}
