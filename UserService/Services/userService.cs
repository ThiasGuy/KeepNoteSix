using UserService.Entities;
using UserService.Exception;
using UserService.Repository;

namespace UserService.Services
{
    public class userService : IUserService
    {
        private readonly IUserRepo _repo;
        public userService(IUserRepo repo)
        {
            _repo = repo;
        }

        public bool DeleteUser(string userId)
        {
            try
            {
                var obj = _repo.DeleteUser(userId);
                if (obj == false)
                {
                    throw new UserNotFoundException("User Not Found");
                }
                return true;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
        }

        public List<User> GetUser()
        {
            return _repo.GetUser();
        }

        public User GetUserById(string userId)
        {
            try
            {
                var obj = _repo.GetUserById(userId);
                if (obj == null)
                {
                    throw new UserNotFoundException($"User with {userId} not found");
                }
                return obj;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
        }

        public User RegisterUser(User user)
        {
            try
            {
                var obj = _repo.RegisterUser(user);
                if (obj == null)
                {
                    throw new UserNotCreatedException($"User with {user.UserId} already exists");
                }
                return obj;
            }
            catch (UserNotCreatedException)
            {
                throw;
            }
        }

        public bool UpdateUser(string userId, User user)
        {
            try
            {
                var obj = _repo.UpdateUser(userId, user);
                if (obj == false)
                {
                    throw new UserNotFoundException("User Not Found");
                }
                return true;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
        }
    }
}
