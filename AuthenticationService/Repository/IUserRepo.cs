using AuthenticationService.Entities;

namespace AuthenticationService.Repository
{
    public interface IUserRepo
    {
        bool CreateUser(User user);
        bool IsUserExists(int userId);

        bool LoginUser(User user);
    }
}
