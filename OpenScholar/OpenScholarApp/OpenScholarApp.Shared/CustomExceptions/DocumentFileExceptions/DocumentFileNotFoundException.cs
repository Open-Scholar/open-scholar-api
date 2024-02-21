namespace OpenScholarApp.Shared.CustomExceptions.DocumentFileExceptions
{
    public class DocumentFileNotFoundException : Exception
    {
        public DocumentFileNotFoundException(string message) : base(message) { }
    }
}
