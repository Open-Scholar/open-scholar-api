namespace OpenScholarApp.Shared.CustomExceptions.TopicExceptions
{
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException(string message) : base(message) { }
    }
}
