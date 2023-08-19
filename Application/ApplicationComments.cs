﻿using Application_Contracts.Application_Comment;
using Domain;
using Domain.CommentAgg;
using Domain.DomainServices;

namespace Application
{
    public class ApplicationComments : IApplicationComments
    {
        private readonly ICommentServices _services;
        private readonly IDomainValidator _validator;

        public ApplicationComments(ICommentServices services, IDomainValidator validator)
        {
            _services = services;
            _validator = validator;
        }
        public void AddComment(AddCommentCommand command)
        {
            var comment = new Comment(command.Content, command.blogId);
            _services.AddComment(comment, command.Email, command.Fullname);
        }
        public List<CommentViewModel> GetBlogComments(int blogId)
        {
            return _services.GetAllCommentsBy(c => c.blogId == blogId).Select(CommentViewModelInitialize()).ToList();
        }
        public List<CommentViewModel> GetAllCommentsBy(int statusCode)
        {
            var comments = _services.GetAllCommentsBy(c => c.status == statusCode).Select(CommentViewModelInitialize()).ToList();
            return comments;
        }

        public CommentViewModel FindCommentBy(int commentId)
        {
            var comment = _services.FindComment(c => c.Id == commentId);
            return new CommentViewModel
            {
                Content = comment.text,
                blogId = comment.blogId,
                BlogTitle = comment.blog.Title,
                Status = comment.status,
                Id = comment.Id,
                userId = comment.user.id
            };
        }

        public void DeleteComment(int commentId)
        {
            _services.DeleteComment(commentId);
        }

        public void ChangeStatusCode(int commentId, StatusCode code)
        {
            _services.ChangeStatusCode(commentId, code);
        }
        public List<CommentViewModel> GetAllComments()
        {
            return _services.GetAllCommentsBy().Select(CommentViewModelInitialize()).ToList();
        }
        private static Func<Comment, CommentViewModel> CommentViewModelInitialize()
        {
            //A piece of code must not be repeated 
            return v => new CommentViewModel
            {
                BlogTitle = v.blog.Title,
                Content = v.text,
                userId = v.user.id,
                Status = v.status,
                Id = v.Id,
                blogId = v.blogId
            };
        }
    }
}
