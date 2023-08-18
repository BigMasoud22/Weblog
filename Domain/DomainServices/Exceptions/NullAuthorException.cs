namespace Domain.DomainServices.Exceptions
{
    public class NullAuthorException : Exception
    {
        public NullAuthorException() { }

        public NullAuthorException(string? message) : base(message)
        {
        }
    }
}
