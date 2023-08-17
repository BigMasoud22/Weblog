using Domain.UserAgg;

namespace Domain.BlogAgg
{
    public class Blog
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }

        public DateTime ReleaseDate = DateTime.Now;

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
            this.ReleaseDate = DateTime.Now;
        }
        public Blog(string title, string body, string description)
        {
            this.Title = title;
            this.Body = body;
            this.Description = description;
            this.IsDeleted = false;
            this.ReleaseDate = DateTime.Now;
        }

        public Blog(int id, string title, string body, string description)
        {
            Id = id;
            Title = title;
            Body = body;
            Description = description;
        }

        public virtual User Author { get; set; }
        public virtual BlogImage? image { get; set; }
        public void AddImage(string imageAddress, string altText, string imageTitle)
        {
            var picture = new BlogImage(imageTitle, altText, imageAddress);
            this.image = picture;
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
            this.Id= blog.Id;
            this.Title = blog.Title;
            this.Body = blog.Body;
            this.Description = blog.Description;
            if (blog.image != null)
            {
                this.image.UpdateImage(blog.image);
            }
        }
    }
}
