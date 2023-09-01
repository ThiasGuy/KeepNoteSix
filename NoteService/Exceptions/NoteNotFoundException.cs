namespace NoteService.Exceptions
{
    public class NoteNotFoundException : ApplicationException
    {
        public NoteNotFoundException() : base() { }
        public NoteNotFoundException(string message) : base(message) { }
    }
}
