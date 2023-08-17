using Domain.BlogAgg;
using Domain.UserAgg;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Main.Controllers
{
    [Area("Main")]
    public class HomeController : Controller
    {
        #region Services
        private Context _context;
        private IUserServices _applicationUserService;
        private IBlogServices _blogServices;
        public HomeController(Context context
       , IUserServices applicationUserService
       , IBlogServices blogServices)
        {
            _applicationUserService = applicationUserService;
            _context = context;
            _blogServices = blogServices;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult ArticleDownload()
        //{
        //	var byteslice = System.IO.File.ReadAllBytes("wwwroot/CheetSheetPandas.pdf");
        //	const string filename = "Article.pdf";
        //	return File(byteslice, MediaTypeNames.Application.Pdf, filename);
        //}
    }
}
