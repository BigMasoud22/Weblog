using Domain;
using Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.ServiceIMP
{
    public class CommentServices : ICommentServices
    {
        private readonly Context _context;
        public CommentServices(Context context)
        {
            _context = context;
        }
        public bool AddComment(Comment comment, string email, string fullname)
        {
            var user = _context.users.FirstOrDefault(x => x.Email == email&&x.FullName==fullname);
            if (user == null)
            {
                user = new Domain.UserAgg.User(email,fullname);
            }
            comment.AssignAuthor(user);
            _context.comments.Add(comment);
            _context.SaveChanges();

            return true;
        }
        public bool ChangeStatusCode(int commentId, StatusCode code)
        {
            var comment = FindComment(c => c.Id == commentId);
            comment.ChangeStatus(code);

            if (_context.SaveChanges() != 1)
                return true;

            return false;
        }
        public bool DeleteComment(int commentId)
        {
            var comment = FindComment(c => c.Id == commentId);
            _context.comments.Remove(comment);
            if (_context.SaveChanges() == 1)
                return true;

            return false;
        }
        public Comment FindComment(Expression<Func<Comment, bool>> expression)
        {
            return _context.comments.FirstOrDefault(expression);
        }
        public List<Comment> GetAllCommentsBy(int blogId)
        {
            return _context.comments.Include(b=>b.blog).Where(c => c.blogId == blogId).ToList();
        }
        public List<Comment> GetAllCommentsBy(Expression<Func<Comment, bool>> expression)
        {
            return _context.comments.Include(b => b.blog).Where(expression).ToList();
        }

        public List<Comment> GetAllCommentsBy()
        {
            return _context.comments.Include(b=>b.blog).Include(u=>u.user).ToList();
        }
    }
}
