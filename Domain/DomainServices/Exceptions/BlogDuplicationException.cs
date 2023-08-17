namespace Domain.DomainServices.Exceptions
{
    public class BlogDuplicationException : Exception
    {
        public BlogDuplicationException()
        {

        }
        public BlogDuplicationException(string message)
            : base(message)
        {

        }
    }
}
