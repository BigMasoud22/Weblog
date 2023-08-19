using Domain.BlogAgg;
using Domain.UserAgg;
using System.Linq.Expressions;

namespace Domain.BlogAgg;

public interface IBlogServices
{
    List<Blog> SelectAllBlogs();
    Blog FindBlog(Expression<Func<Blog, bool>> expression);
    bool DeleteBlog(int BlogId);
    bool AddBlog(Blog blog, string email, string fullname);
    bool Update(Blog blog);
    void ActivateBlog(int blogId);
}
