namespace ReminderService.Enitities
{
    public class ReminderStoreDatabaseSetting : IReminderStoreDatabaseSetting
    {
        public string ReminderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
