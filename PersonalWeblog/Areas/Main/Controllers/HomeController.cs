using Application_Contracts.Application_Blog;
using Domain.BlogAgg;
using Domain.UserAgg;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace PersonalWeblog.Main.Controllers
{
    [Area("Main")]
    public class HomeController : Controller
    {
        #region Services
        private Context _context;
        private IBlogApplication _blogServices;
        private IWebHostEnvironment _webHostEnvironment;
        public HomeController(Context context
       , IBlogApplication blogServices
       , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _blogServices = blogServices;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ArticleDownload(int blogId)
        {
            var blog = _blogServices.GetBlog(blogId);
            var rootpath = _webHostEnvironment.WebRootPath;
            var filename = "\\"+Guid.NewGuid().ToString();
            using (var stream = new StreamWriter(_webHostEnvironment.WebRootPath + $"{filename}.txt", true, encoding: System.Text.Encoding.UTF8))
            {
                stream.WriteLine(blog.BlogTitle);
                stream.Write(blog.BlogBody);
            }

            var byteslice = System.IO.File.ReadAllBytes(rootpath+filename+".txt");
            string fullname = filename+".txt";
            return File(byteslice, MediaTypeNames.Text.RichText, fullname);
        }
        public IActionResult ViewBlogDetail(int blogId)
        {
            var blog = _blogServices.GetBlog(blogId);
            return View(blog);
        }

    }
}
