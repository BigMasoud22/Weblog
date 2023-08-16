using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.BlogAgg
{
    public class BlogImage
    {
        public int Id { get;private set; }
        public string Title { get; private set; }
        public string alttext { get; private set; }
        public string imgAddress { get; private set; }
        public bool Isdeleted { get; private set; }
        public int blogId { get; private set; }
        public virtual Blog blog { get; set; }
        public BlogImage() { }
        public BlogImage(string title, string alttext, string imgAddress)
        {
            this.Title = title;
            this.alttext = alttext;
            this.imgAddress = imgAddress;
            Isdeleted = false;
        }
        public void Delete()
        {
            this.Isdeleted = true;
        }
        public void UpdateImage(BlogImage image)
        {
            this.Title = image.Title;
            this.alttext = image.alttext;
            this.imgAddress = image.imgAddress;
        }
    }
}
