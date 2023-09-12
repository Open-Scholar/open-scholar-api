namespace OpenScholarApp.Shared.CustomExceptions.AuthorExceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(string message) : base(message)  { }
    }
}
