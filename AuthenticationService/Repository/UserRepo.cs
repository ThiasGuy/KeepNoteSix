using AuthenticationService.Entities;

namespace AuthenticationService.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDbContext _context;

        public UserRepo(UserDbContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool IsUserExists(int userId)
        {
            var obj = _context.users.FirstOrDefault(x => x.UserId == userId);
            if (obj != null)
                return true;
            return false;
        }

        public bool LoginUser(User user)
        {
            var obj = _context.users.FirstOrDefault(x => x.UserId == user.UserId && x.Password == user.Password);
            if (obj != null)
                return true;
            return false;
        }
    }
}
