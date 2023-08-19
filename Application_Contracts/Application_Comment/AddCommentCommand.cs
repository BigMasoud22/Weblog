namespace Application_Contracts.Application_Comment
{
    public class AddCommentCommand
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int blogId { get; set; }
        public AddCommentCommand() { }
    }
}
