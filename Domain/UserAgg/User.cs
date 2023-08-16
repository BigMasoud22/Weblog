using Domain.BlogAgg;

namespace Domain.UserAgg
{
    public class User
    {
        public int id { get; private set; }
        public string Email { get; private set; }
        public string? Phonenumber { get; private set; }
        public string FullName { get; private set; }
        public bool IsActive { get; set; }

        public User()
        {

        }

        public User(string email, string? phonenumber, string fullName)
        {
            Email = email;
            Phonenumber = phonenumber;
            FullName = fullName;
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }
        public void Update(string email, string phonenumber, string fullname)
        {
            this.Email = email;
            this.Phonenumber = phonenumber;
            this.FullName = fullname;
        }

        public virtual List<Blog>? Blogs { get; set; }
    }
}
