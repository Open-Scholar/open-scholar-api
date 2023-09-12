namespace OpenScholarApp.Shared.CustomExceptions.BookStoreExceptions
{
    public class BookStoreNotFoundException : Exception
    {
        public BookStoreNotFoundException(string message) : base(message) { }
    }
}
