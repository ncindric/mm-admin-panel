namespace AdminPanel.Abstractions.Core.Results
{
    public static class ResultFactory
    {
        public static Result Success() => new(true, string.Empty);

        public static Result Failure(string message) => new(false, message);
    }
}