namespace Application_Contracts.Application_Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public int userId { get; set; }
        public string authorName { get; set; }
        public string BlogTitle { get; set; }
        public int blogId { get; set; }
    }
}
