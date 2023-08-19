using Domain.CommentAgg;
using Domain.UserAgg;
using Framework.Domain;

namespace Domain.BlogAgg
{
    public class Blog : DomainBase<int>
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }

        public Blog()
        {

        }
        public Blog(string title, string body, string description, DomainServices.IDomainValidator validator)
        {
            validator.IsBlogExists(this);
            this.Title = title;
            this.Body = body;
            this.Description = description;
            this.IsDeleted = false;
        }
        public Blog(string title, string body, string description)
        {
            this.Title = title;
            this.Body = body;
            this.Description = description;
            this.IsDeleted = false;
        }
        public Blog(int id, string title, string body, string description)
        {
            Title = title;
            Body = body;
            Description = description;
        }
        public virtual User Author { get; private set; }
        public virtual BlogImage? image { get; private set; }
        public virtual List<Comment>? comments { get; private set; }
        public void AddImage(string imageAddress, string altText, string imageTitle)
        {
            var picture = new BlogImage(imageTitle, altText, imageAddress);
            this.image = picture;
        }
        public void AssignAuthor(User user)
        {
            if (user == null)
                throw new ArgumentNullException("the author instance is null");

            this.Author = user;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
        public void Update(Blog blog)
        {
            this.Title = blog.Title;
            this.Body = blog.Body;
            this.Description = blog.Description;
            if (blog.image != null)
            {
                this.image.UpdateImage(blog.image);
            }
        }
        public void AddComment(Comment comment)
        {
            this.comments.Add(comment);
        }
    }
}
