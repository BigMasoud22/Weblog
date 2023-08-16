namespace Application_Contracts.Application_Blog
{
    public class BlogViewModel : CreateBlogCommand
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
    }
}
