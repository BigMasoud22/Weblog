namespace Application_Contracts.Application_Blog
{
    public class BlogDemonstrateAdmin
    {
        public int blogId { get; set; }
        public bool isDelete { get; set; }
        public string title { get; set; }
        public string desctiption { get; set; }
        public int authorId { get; set; }
    }
}
