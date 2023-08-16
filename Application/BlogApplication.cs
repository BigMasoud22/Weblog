using Application_Contracts.Application_Blog;
using Domain.BlogAgg;
using System.ComponentModel.Design;

namespace Application
{
    public class BlogApplication : IBlogApplication
    {
        private IBlogServices _services;

        public BlogApplication(IBlogServices services)
        {
            _services = services;
        }

        public void CreateBlog(CreateBlogCommand command)
        {
            var blog = new Blog(command.BlogTitle, command.BlogBody, command.BlogDescrioption);
            if (command.ImageTitle != null && command.ImageAddress != null && command.AltText != null)
            {
                blog.AddImage(command.ImageAddress, command.AltText, command.ImageTitle);
            }
            _services.AddBlog(blog);
        }

        public void DeleteBlog(int blogId)
        {
            _services.DeleteBlog(blogId);
        }

        public List<BlogViewModel> GetAllBlogs()
        {
            var allBlogs = _services.SelectAllBlogs();
            var ListBlogVM = allBlogs.Select(blog => new BlogViewModel
            {
                Id = blog.Id,
                BlogTitle = blog.Title,
                AltText = blog.image != null ? blog.image.alttext : null,
                ImageAddress = blog.image != null ? blog.image.imgAddress : null,
                IsDeleted = blog.IsDeleted,
                BlogBody = blog.Body,
                BlogDescrioption = blog.Description,
                BlogAuthorId = blog.Author.id,
                CreationDate = blog.ReleaseDate.ToShortDateString(),
                ImageTitle = blog.image != null ? blog.image.Title : null,
            }).ToList();
            return ListBlogVM;
        }

        public BlogViewModel GetBlog(int blogId)
        {
            var blog = _services.FindBlog(b => b.Id == blogId);
            var Blogvm = new BlogViewModel
            {
                Id = blog.Id,
                BlogTitle = blog.Title,
                AltText = blog.image != null ? blog.image.alttext : null,
                ImageAddress = blog.image != null ? blog.image.imgAddress : null,
                IsDeleted = blog.IsDeleted,
                BlogBody = blog.Body,
                BlogDescrioption = blog.Description,
                BlogAuthorId = blog.Author.id,
                CreationDate = blog.ReleaseDate.ToShortDateString(),
                ImageTitle = blog.image != null ? blog.image.Title : null,
            };
            return Blogvm;
        }

        public void UpdateBlog(BlogViewModel commannd)
        {
            var blog = _services.FindBlog(b => b.Id == commannd.Id);
            var updateBlog = new Blog(commannd.BlogTitle,commannd.BlogBody,commannd.BlogDescrioption);
            _services.Update(updateBlog);
            if (commannd.ImageAddress != null && commannd.ImageTitle != null && commannd.AltText != null)
            {
                var updateImage = new BlogImage(commannd.ImageTitle, commannd.AltText, commannd.ImageAddress);
                _services.UpdateImage(updateImage);
            }
        }

    }
}