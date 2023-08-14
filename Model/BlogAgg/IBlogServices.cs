using Domain.BlogAgg;
using System.Linq.Expressions;

namespace Domain.BlogAgg;

public interface IBlogServices
{
    List<Blog> SelectAllBlogs();
    Blog FindBlog(Expression<Func<Blog, bool>> expression);
    bool DeleteBlog(int BlogId);
    bool AddBlog(Blog blog);
    bool Update(Blog blog);
}
