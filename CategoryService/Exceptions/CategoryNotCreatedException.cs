namespace CategoryService.Exceptions
{
    public class CategoryNotCreatedException : ApplicationException
    {
        public CategoryNotCreatedException() : base() { }
        public CategoryNotCreatedException(string message) : base(message) { }
    }
}
