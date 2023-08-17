using Application_Contracts.Application_Blog;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IBlogApplication _blogApplication;
        public AdminController(IBlogApplication blogApplication)
        {
            _blogApplication = blogApplication;
        }
        public IActionResult Index()
        {

            return View(_blogApplication.GetBlogsForDemonstrate());
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            var addBlogCommand = new CreateBlogCommand();
            return View(addBlogCommand);
        }
        [HttpPost]
        public IActionResult CreateBlog(CreateBlogCommand command)
        {
            command.ImageAddress = "this is a image address in asp test";
            _blogApplication.CreateBlog(command);
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int blogId)
        {
            var blog = _blogApplication.GetBlog(blogId ,true);
            return View(blog);
        }
        [HttpPost]
        public IActionResult UpdateBlog(UpdateBlogCommand command)
        {
            command.ImageAddress = "this is a image address in asp test";
            _blogApplication.UpdateBlog(command);
            return Redirect("Index");
        }
        public IActionResult DeleteBlog(int blogId)
        {
            _blogApplication.DeleteBlog(blogId);
            return Redirect("Index");
        }
        public IActionResult ActivateBlog(int blogid)
        {
            _blogApplication.ActivateBlog(blogid);
            return Redirect("Index");
        }
    }
}
