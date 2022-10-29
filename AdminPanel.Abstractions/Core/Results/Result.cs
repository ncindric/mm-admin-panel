namespace AdminPanel.Abstractions.Core
{
    public class Result
    {
        internal Result(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }

        public string Message { get; set; }
    }
}