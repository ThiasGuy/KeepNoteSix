namespace ReminderService.Exceptions
{
    public class ReminderNotCreatedException : ApplicationException
    {
        public ReminderNotCreatedException() : base(){ }
        public ReminderNotCreatedException(string message) : base(message) { }
    }
}
