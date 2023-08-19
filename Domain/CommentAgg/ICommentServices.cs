using System.Linq.Expressions;

namespace Domain.CommentAgg
{
    public interface ICommentServices
    {
        List<Comment> GetAllCommentsBy(int blogId);
        List<Comment> GetAllCommentsBy(Expression<Func<Comment , bool>> expression);
        List<Comment> GetAllCommentsBy();
        Comment FindComment(Expression<Func<Comment, bool>> expression);
        bool DeleteComment(int CommentId);
        bool AddComment(Comment comment , string email , string fullname);
        bool ChangeStatusCode(int commentId , StatusCode code);
    }
}
