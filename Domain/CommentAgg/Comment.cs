using Domain.BlogAgg;
using Domain.UserAgg;

namespace Domain.CommentAgg
{
    public class Comment
    {
        public int Id { get; private set; }
        public string text { get; private set; }
        public DateTime date { get; private set; }
        public int status { get; private set; }
        public int blogId { get; private set; }
        public Blog blog { get; private set; }
        public int userId { get; private set; }
        public User user { get; private set; }
        protected Comment() { }

        public Comment(string text, int blogId)
        {
            this.text = text;
            this.date = DateTime.Now;
            this.blogId = blogId;
            this.userId = userId;
            this.status = (int)StatusCode.Checking;
        }
        public void ChangeStatus(StatusCode code)
        {
            this.status = (int)code;
        }
        public void AssignAuthor(User user)
        {
            this.user = user;
        }
        public void AssignBlog(Blog blog)
        {
            this.blog = blog;
        }
    }
}
