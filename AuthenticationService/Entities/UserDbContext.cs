using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Entities
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
    }
}
