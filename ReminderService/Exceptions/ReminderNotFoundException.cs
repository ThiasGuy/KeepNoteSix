namespace ReminderService.Exceptions
{
    public class ReminderNotFoundException : ApplicationException
    {
        public ReminderNotFoundException() : base() { }
        public ReminderNotFoundException(string message) : base(message) { }
    }
}
