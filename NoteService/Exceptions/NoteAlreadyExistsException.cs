namespace NoteService.Exceptions
{
    public class NoteAlreadyExistsException : ApplicationException
    {
        public NoteAlreadyExistsException() : base() { }
        public NoteAlreadyExistsException(string message) : base(message) { }
    }
}
