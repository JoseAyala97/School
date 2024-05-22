namespace School.Exceptions.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }
        public CodeErrorException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}