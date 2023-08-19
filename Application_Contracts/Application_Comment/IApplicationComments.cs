using Domain;

namespace Application_Contracts.Application_Comment
{
    public interface IApplicationComments
    {
        void AddComment(AddCommentCommand command);
        List<CommentViewModel> GetBlogComments(int blogId);
        List<CommentViewModel> GetAllCommentsBy(int statusCode);
        List<CommentViewModel> GetAllComments();
        CommentViewModel FindCommentBy(int commentId);
        void DeleteComment(int commentId);
        void ChangeStatusCode(int commentId, StatusCode code);
    }
}
