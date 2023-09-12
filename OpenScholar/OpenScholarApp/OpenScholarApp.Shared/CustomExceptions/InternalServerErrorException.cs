namespace OpenScholarApp.Shared.CustomExceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base("An error occurred, contact the admin!")
        {

        }
    }
}
