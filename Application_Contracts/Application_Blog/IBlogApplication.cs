namespace Application_Contracts.Application_Blog
{
    public interface IBlogApplication
    {
        List<BlogViewModel> GetAllBlogs();
        void CreateBlog(CreateBlogCommand command);
        void DeleteBlog(int blogId);
        BlogViewModel GetBlog(int blogId);
        void UpdateBlog(BlogViewModel command);
    }
}
