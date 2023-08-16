using Domain.BlogAgg;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.ServiceIMP
{
    public class BlogServices : IBlogServices
    {
        private Context _context;
        public BlogServices(Context context)
        {
            _context = context;
        }
        public bool AddBlog(Blog blog)
        {
            _context.blogs.Add(blog);
            var saved = _context.SaveChanges();
            if (saved == 1)
                return true;

            return false;
        }
        public bool DeleteBlog(int BlogId)
        {
            var blog = FindBlog(u => u.Id == BlogId);
            //_context.blogs.Remove(users);
            blog.Delete();
            var isSaved = _context.SaveChanges();
            if (isSaved == 1) return true;
            return false;
        }
        public Blog FindBlog(Expression<Func<Blog, bool>> expression)
        {
            return _context.blogs.Include(b => b.image).FirstOrDefault(expression);
        }
        public List<Blog> SelectAllBlogs()
        {
            return _context.blogs.Include(b => b.image).ToList();
        }
        public List<Blog> SelectAllBlogs(Expression<Func<Blog, bool>> expression)
        {
            return _context.blogs.Where(expression).ToList();
        }
        public bool Update(Blog blog)
        {
            //_context.Update(blog);
            blog.Update(blog);
            var isSaved = _context.SaveChanges();
            if (isSaved == 1)
                return true;

            return false;
        }
        public bool UpdateImage(BlogImage image)
        {
            image.UpdateImage(image);
            var isSaved = _context.SaveChanges();
            if (isSaved ==1)
                return true;
            return false;
        }
    }
}
