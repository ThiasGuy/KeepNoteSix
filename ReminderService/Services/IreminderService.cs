using ReminderService.Enitities;

namespace ReminderService.Services
{
    public interface IreminderService
    {
        Reminder CreateReminder(Reminder reminder);
        bool DeleteReminder(string reminderId);
        bool UpdateReminder(string reminderId, Reminder reminder);
        Reminder GetReminderById(string reminderId);
        List<Reminder> GetAllRemindersByUserId(string userId);
    }
}
