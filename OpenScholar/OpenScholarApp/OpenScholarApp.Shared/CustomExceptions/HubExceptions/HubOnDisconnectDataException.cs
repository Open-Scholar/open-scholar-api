namespace OpenScholarApp.Shared.CustomExceptions.HubExceptions
{
    public class HubOnDisconnectDataException : Exception
    {
        public HubOnDisconnectDataException(string message) : base(message) { }
    }
}
