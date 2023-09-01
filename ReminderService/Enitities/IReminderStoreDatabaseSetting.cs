namespace ReminderService.Enitities
{
    public interface IReminderStoreDatabaseSetting
    {
        string ReminderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
