using Domain.BlogAgg;
using Domain.UserAgg;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Areas.Main.Controllers
{
    [Area("Main")]
	public class HomeController : Controller
	{
		#region Services
		private Context _context;
		private IUserServices _applicationUserService;
		private IBlogServices _blogServices;
		private RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		public HomeController(Context context
	   , IUserServices applicationUserService
	   , UserManager<IdentityUser> userManager
	   , RoleManager<IdentityRole> roleManager
	   , SignInManager<IdentityUser> signInManager
	   , IBlogServices blogServices)
		{
			_userManager = userManager;
			_applicationUserService = applicationUserService;
			_context = context;
			_roleManager = roleManager;
			_signInManager = signInManager;
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
