namespace OpenScholarApp.Shared.CustomExceptions.FacultyExceptions
{
    public class FacultyNotFoundException : Exception
    {
        public FacultyNotFoundException(string message) : base(message) { }
    }
}
