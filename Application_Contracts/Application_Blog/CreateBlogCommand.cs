using System.Drawing;
using System.Globalization;

namespace Application_Contracts.Application_Blog
{
    public class CreateBlogCommand
    {
        public string BlogTitle { get; set; }
        public string BlogDescrioption { get; set; }
        public string BlogBody { get; set; }
        public int BlogAuthorId { get; set; }
        public string? ImageAddress { get; set; }
        public string? AltText { get; set; }
        public string? ImageTitle { get; set; }
        public CreateBlogCommand()
        {
            
        }

        public CreateBlogCommand(string blogTitle, string blogDescrioption, string blogBody, int blogAuthorId)
        {
            BlogTitle = blogTitle;
            BlogDescrioption = blogDescrioption;
            BlogBody = blogBody;
            BlogAuthorId = blogAuthorId;
        }
        public CreateBlogCommand(string blogTitle, string blogDescrioption, string blogBody, int blogAuthorId, string? imageAddress, string? altText, string? imageTitle)
        {
            BlogTitle = blogTitle;
            BlogDescrioption = blogDescrioption;
            BlogBody = blogBody;
            BlogAuthorId = blogAuthorId;
            ImageAddress = imageAddress;
            AltText = altText;
            ImageTitle = imageTitle;
        }
    }
}
