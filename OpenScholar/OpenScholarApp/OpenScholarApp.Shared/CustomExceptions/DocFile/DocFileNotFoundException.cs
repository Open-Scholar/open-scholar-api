namespace OpenScholarApp.Shared.CustomExceptions.DocFile
{
    public class DocFileNotFoundException : Exception
    {
        public DocFileNotFoundException(string message) : base(message) { }
    }
}
