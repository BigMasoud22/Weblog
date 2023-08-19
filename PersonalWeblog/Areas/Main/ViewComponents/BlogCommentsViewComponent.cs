using Application_Contracts.Application_Comment;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Areas.Main.ViewComponents
{
    public class BlogCommentsViewComponent : ViewComponent
    {
        private readonly IApplicationComments _services;
        public BlogCommentsViewComponent(IApplicationComments services)
        {
            _services = services;
        }

        public IViewComponentResult Invoke(int blogId)
        {
            var comments = _services.GetBlogComments(blogId);
            return View("_Comments", comments);
        }

    }
}
