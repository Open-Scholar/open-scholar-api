namespace OpenScholarApp.Shared.CustomExceptions.BookException
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message) : base(message) { }
    }
}
