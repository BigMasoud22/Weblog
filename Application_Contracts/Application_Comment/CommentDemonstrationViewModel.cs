namespace Application_Contracts.Application_Comment
{
    public class CommentDemonstrationViewModel
    {
        public int blogId { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }

        public CommentDemonstrationViewModel(int blogId, string authorName, string content)
        {
            this.blogId = blogId;
            AuthorName = authorName;
            Content = content;
        }
    }
}
