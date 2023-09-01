using MongoDB.Driver;
using ReminderService.Enitities;

namespace ReminderService.Repository
{
    public class ReminderRepo : IReminderRepo
    {

        private readonly IMongoCollection<Reminder> _reminders;

        public ReminderRepo(IReminderStoreDatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _reminders = database.GetCollection<Reminder>(setting.ReminderCollectionName);
        }

        public Reminder CreateReminder(Reminder reminder)
        {
            _reminders.InsertOne(reminder);
            return reminder;
        }

        public bool DeleteReminder(string reminderId)
        {
            var result = _reminders.DeleteOne(Builders<Reminder>.Filter.Eq("Id", reminderId));

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public List<Reminder> GetAllReminders()
        {
            return _reminders.Find(p => true).ToList();
        }

        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return _reminders.Find(p => p.CreatedBy == userId).ToList();
        }

        public Reminder GetReminderById(string reminderId)
        {
            return _reminders.Find(p => p.Id == reminderId).FirstOrDefault();
        }

        public bool UpdateReminder(string reminderId, Reminder reminder)
        {
            var filter = Builders<Reminder>.Filter.Eq("Id", reminderId);
            var result = _reminders.ReplaceOne(filter, reminder);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
