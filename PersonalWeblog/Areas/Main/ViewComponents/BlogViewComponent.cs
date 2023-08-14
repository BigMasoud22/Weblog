using Domain.BlogAgg;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWeblog.Areas.Main.ViewComponents;

public class BlogViewComponent : ViewComponent
{
    private IBlogServices _iblogservices;
    public BlogViewComponent(IBlogServices iblogservices)
    {
        _iblogservices = iblogservices;
    }
    public IViewComponentResult Invoke()
    {
        var blogs = _iblogservices.SelectAllBlogs().Take(6).ToList();
        return View("_Blog", blogs);
    }
}