using Domain.BlogAgg;
using Domain.CommentAgg;

namespace Domain.UserAgg
{
    public class User
    {
        public int id { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public bool IsActive { get; private set; }

        public User()
        {

        }

        public User(string email, string fullName)
        {
            Email = email;
            FullName = fullName;
            IsActive = true;
            blogs = new List<Blog>();
        }

        public void DeActive()
        {
            IsActive = false;
        }
        public void Update(string email, string fullname)
        {
            this.Email = email;
            this.FullName = fullname;
        }
        public virtual List<Blog>? blogs { get; private set; }
        public virtual List<Comment>? comments { get; private set; }
    }
}
