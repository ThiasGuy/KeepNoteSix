using UserService.Entities;

namespace UserService.Repository
{
    public interface IUserRepo
    {
        User RegisterUser(User user);
        bool UpdateUser(string userId, User user);
        bool DeleteUser(string userId);
        User GetUserById(string userId);

        List<User> GetUser();
    }
}
