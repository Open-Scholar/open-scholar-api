namespace OpenScholarApp.Shared.CustomExceptions.ProfessorExceptions
{
    public class ProfessorNotFoundException : Exception
    {
        public ProfessorNotFoundException(string message) : base(message) { }
    }
}
