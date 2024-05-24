namespace School.Exceptions.Errors
{
        public class InternalServerErrorException : ApplicationException
    {
        public InternalServerErrorException(string? message) : base(message)
        {
        }
    }
}