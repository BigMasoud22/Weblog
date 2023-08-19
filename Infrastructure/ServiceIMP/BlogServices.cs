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
        public void ActivateBlog(int blogId)
        {
            var user = FindBlog(b => b.Id == blogId);
            user.Activate();
            _context.SaveChanges();
        }
        public bool AddBlog(Blog blog ,string email,string fullname)
        {
            var user = _context.users.FirstOrDefault(u=>u.Email==email&&u.FullName==fullname);
            if (user == null)
            {
                user = new Domain.UserAgg.User(email,fullname);
            }
            blog.AssignAuthor(user);
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
            return _context.blogs.Include(b => b.image).Include(b => b.Author).FirstOrDefault(expression);
        }
        public List<Blog> SelectAllBlogs()
        {
            return _context.blogs.Include(p => p.image).Include(u => u.Author).Include(c => c.comments).ToList();
        }
        public List<Blog> SelectAllBlogs(Expression<Func<Blog, bool>> expression)
        {
            return _context.blogs.Where(expression).Include(p => p.image).ToList();
        }
        public bool Update(Blog blog)
        {
            //the consentration is on blog at this point so 
            //the blog author setted on the first record of users in database in order to preventing possible errors
            blog.AssignAuthor(_context.users.FirstOrDefault());
            var TheBlog = FindBlog(b => b.Id == blog.Id);
            TheBlog.Update(blog);
            var isSaved = _context.SaveChanges();
            if (isSaved == 1)
                return true;
            return false;
        }
    }
}
