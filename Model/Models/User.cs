using Microsoft.AspNetCore.Identity;

namespace Model.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }

        public virtual List<Blog>? Blogs { get; set; }
    }
}
