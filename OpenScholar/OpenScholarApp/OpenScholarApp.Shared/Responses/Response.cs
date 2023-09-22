namespace OpenScholarApp.Shared.Responses
{
    public class Response
    {
        public bool IsSuccessfull { get; set; } = false;
        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public static Response Success => new(true);
        public Response(params string[] errors) => Errors = errors;
        public Response(IEnumerable<string> errors) => Errors = errors;
        public Response(bool isSuccessfull) => IsSuccessfull = isSuccessfull;
    }

    public class Response<TResult> : Response where TResult : new()
    {
        public TResult? Result { get; set; } = default;
        public Response(TResult? result)
        {
            IsSuccessfull = true;
            Result = result;
        }
        public Response(params string[] errors) : base(errors) { }
        public Response(IEnumerable<string> errors) : base(errors) { }
    }
}
