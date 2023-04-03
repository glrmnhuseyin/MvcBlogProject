using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
