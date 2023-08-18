using Domain.BlogAgg;
using Domain.UserAgg;

namespace Domain.CommentAgg
{
    public class Comment
    {
        public int Id { get; private set; }
        public string text { get; private set; }
        public DateTime date { get; private set; }
        public int blogId { get; private set; }
        public Blog blog { get; set; }
        public int userId { get; private set; }
        public User user { get; set; }
        protected Comment() { }

        public Comment(string text, int blogId, int userId)
        {
            this.text = text;
            this.date = DateTime.Now;
            this.blogId = blogId;
            this.userId = userId;
        }
    }
}
