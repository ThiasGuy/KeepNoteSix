namespace CategoryService.Exceptions
{
    public class CategoryNotFoundException : ApplicationException
    {
        public CategoryNotFoundException() : base() { }
        public CategoryNotFoundException(string message) : base(message) { }
    }
}
