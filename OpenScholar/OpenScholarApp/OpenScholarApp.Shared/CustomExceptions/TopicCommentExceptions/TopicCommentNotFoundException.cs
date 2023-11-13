namespace OpenScholarApp.Shared.CustomExceptions.TopicCommentExceptions
{
    public class TopicCommentNotFoundException : Exception
    {
        public TopicCommentNotFoundException(string message) : base(message) { }
    }
}
