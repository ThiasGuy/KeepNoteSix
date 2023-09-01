using AuthenticationService.Entities;
using AuthenticationService.Exceptions;
using AuthenticationService.Repository;

namespace AuthenticationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public bool LoginUser(User user)
        {
            return _repo.LoginUser(user);
        }

        public bool RegisterUser(User user)
        {
            var obj = _repo.IsUserExists(user.UserId);
            if (obj)
            {
                throw new UserAlreadyExistsException($"This User with {user.UserId} already exists");
            }
            return _repo.CreateUser(user);
        }
    }
}
