using MongoDB.Driver;
using UserService.Entities;

namespace UserService.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoCollection<User> _users;

        public UserRepo(IUserStoreDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public bool DeleteUser(string userId)
        {
            var user = _users.Find(p => p.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                return false;
            }

            var result = _users.DeleteOne(Builders<User>.Filter.Eq("UserId", userId));

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public List<User> GetUser()
        {
            return _users.Find(user => true).ToList();
        }

        public User GetUserById(string userId)
        {
            return _users.Find(p => p.UserId == userId).FirstOrDefault();
        }

        public User RegisterUser(User user)
        {
            
           _users.InsertOne(user);
           return user;
            
        }

        public bool UpdateUser(string userId, User user)
        {
            var filter = Builders<User>.Filter.Eq("UserId", userId);
            var result = _users.ReplaceOne(filter, user);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
