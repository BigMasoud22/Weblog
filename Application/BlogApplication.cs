using Application_Contracts.Application_Blog;
using Domain.BlogAgg;
using Domain.DomainServices;

namespace Application
{
    public class BlogApplication : IBlogApplication
    {
        private IBlogServices _services;
        private readonly IDomainValidator _validator;

        public BlogApplication(IBlogServices services, IDomainValidator validator)
        {
            _services = services;
            _validator = validator;
        }

        public void ActivateBlog(int id)
        {
            _services.ActivateBlog(id);
        }

        public void CreateBlog(CreateBlogCommand command)
        {
            var blog = new Blog(command.BlogTitle, command.BlogBody, command.BlogDescrioption , _validator);
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
                BlogAuthorId = blog.Author != null ? blog.Author.id : -1,
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

        public List<BlogDemonstrateAdmin> GetBlogsForDemonstrate()
        {
            return _services.SelectAllBlogs().Select(b => new BlogDemonstrateAdmin()
            {
                blogId = b.Id,
                desctiption = b.Description,
                isDelete = b.IsDeleted,
                title = b.Title,
                authorId = b.Author.id,
            }).ToList();
        }
        public void UpdateBlog(UpdateBlogCommand commannd)
        {
            var updateBlog = new Blog(commannd.Id,commannd.BlogTitle, commannd.BlogBody, commannd.BlogDescrioption);
            updateBlog.AddImage(commannd.ImageAddress,commannd.AltText,commannd.ImageTitle);
            _services.Update(updateBlog);
        }

        public UpdateBlogCommand GetBlog(int blogId, bool isUpdate)
        {
            var blog = _services.FindBlog(b => b.Id == blogId);
            var Blogcmd = new UpdateBlogCommand
            {
                Id = blog.Id,
                BlogTitle = blog.Title,
                AltText = blog.image != null ? blog.image.alttext : null,
                ImageAddress = blog.image != null ? blog.image.imgAddress : null,
                BlogBody = blog.Body,
                BlogDescrioption = blog.Description,
                BlogAuthorId = blog.Author.id,
                ImageTitle = blog.image != null ? blog.image.Title : null,
            };
            return Blogcmd;
        }
    }
}