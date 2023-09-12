namespace OpenScholarApp.Shared.CustomExceptions.SubjectExceptions
{
    public class SubjectNotFoundException : Exception
    {
        public SubjectNotFoundException(string message) : base(message) { }
    }
}
