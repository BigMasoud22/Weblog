using Application_Contracts.Application_Blog;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IBlogApplication _blogApplication;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminController(IBlogApplication blogApplication, IWebHostEnvironment hostEnvironment)
        {
            _blogApplication = blogApplication;
            _hostingEnvironment = hostEnvironment;
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
        public IActionResult CreateBlog(IFormFile image, CreateBlogCommand command)
        {
            command.ImageAddress = UpsertImage(image);
            _blogApplication.CreateBlog(command);
            return Redirect("Index");
        }


        [HttpGet]
        public IActionResult UpdateBlog(int blogId)
        {
            var blog = _blogApplication.GetBlog(blogId, true);
            return View(blog);
        }
        [HttpPost]
        public IActionResult UpdateBlog(IFormFile? image, UpdateBlogCommand command)
        {
            if (image != null)
            {
                if (command.ImageAddress != null)
                {
                    var rootPath = _hostingEnvironment.WebRootPath;
                    var oldPic = Path.Combine(rootPath, command.ImageAddress.TrimStart('\\'));
                    if (System.IO.File.Exists(oldPic))
                    {
                        System.IO.File.Delete(oldPic);
                    }
                }
                var newImageAddress = UpsertImage(image);
                command.ImageAddress = newImageAddress;
            }
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
        private string UpsertImage(IFormFile image)
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            var filename = Guid.NewGuid().ToString();
            var uploadPath = Path.Combine(rootPath, @"images\Blogs");
            var extension = Path.GetExtension(image.FileName);
            using (var stream = new FileStream(Path.Combine(uploadPath, filename + extension), FileMode.Create))
            {
                image.CopyTo(stream);
            }
            var imageAddress = "images/Blogs/" + filename + extension;
            return imageAddress;
        }
    }
}
