namespace Application_Contracts.Application_Blog
{
    public interface IBlogApplication
    {
        List<BlogViewModel> GetAllBlogs();
        void CreateBlog(CreateBlogCommand command);
        void DeleteBlog(int blogId);
        BlogViewModel GetBlog(int blogId);
        UpdateBlogCommand GetBlog(int blogId , bool isUpdate);
        void UpdateBlog(UpdateBlogCommand command);
        List<BlogDemonstrateAdmin> GetBlogsForDemonstrate();
        void ActivateBlog(int id);
    }
}
