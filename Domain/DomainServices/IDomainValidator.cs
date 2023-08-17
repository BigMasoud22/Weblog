using Domain.BlogAgg;

namespace Domain.DomainServices
{
    public interface IDomainValidator
    {
        void IsBlogExists(Blog blog);
    }
}