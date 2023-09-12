namespace OpenScholarApp.Shared.CustomExceptions.StudentExceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }
}
