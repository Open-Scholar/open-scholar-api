namespace OpenScholarApp.Shared.CustomExceptions.BookSellerExceptions
{
    public class BookSellerNotFoundException : Exception
    {
        public BookSellerNotFoundException(string message) : base(message) { }
    }
}
