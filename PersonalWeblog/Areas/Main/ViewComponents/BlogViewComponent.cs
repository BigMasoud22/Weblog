using Application_Contracts.Application_Blog;
using Domain.BlogAgg;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Areas.Main.ViewComponents;

public class BlogViewComponent : ViewComponent
{
    private IBlogApplication _iblogservices;
    public BlogViewComponent(IBlogApplication iblogservices)
    {
        _iblogservices = iblogservices;
    }
    public IViewComponentResult Invoke()
    {
        var blogs = _iblogservices.GetAllBlogs().Take(6).ToList();
        return View("_Blog", blogs);
    }
}