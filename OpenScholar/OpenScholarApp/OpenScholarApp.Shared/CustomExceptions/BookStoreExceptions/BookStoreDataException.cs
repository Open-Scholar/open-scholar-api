namespace OpenScholarApp.Shared.CustomExceptions.BookStoreExceptions
{
    public class BookStoreDataException : Exception
    { 
        public BookStoreDataException(string message) : base(message) { }
    }
}
