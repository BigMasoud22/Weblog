using Domain.BlogAgg;
using Microsoft.AspNetCore.Identity;
using System.Web.Mvc;

namespace Domain.UserAgg
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }


        public virtual List<Blog>? Blogs { get; set; }
    }
}
