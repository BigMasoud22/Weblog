namespace Application_Contracts.Application_Blog
{
    public class UpdateBlogCommand : CreateBlogCommand
    {
        public int Id { get; set; }
    }
}
