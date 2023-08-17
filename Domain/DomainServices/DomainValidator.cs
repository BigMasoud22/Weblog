using Domain.BlogAgg;
using Domain.DomainServices.Exceptions;

namespace Domain.DomainServices
{
    public class DomainValidator : IDomainValidator
    {
        private readonly IBlogServices _services;

        public DomainValidator(IBlogServices services)
        {
            _services = services;
        }

        public void IsBlogExists(Blog blog)
        {
            var theBlog = _services.FindBlog(b => b.Title == blog.Title && b.Description == b.Description && b.Body == blog.Body);
            if (theBlog != null)
                throw new BlogDuplicationException("This blog is already exists ");
        }
    }
}


