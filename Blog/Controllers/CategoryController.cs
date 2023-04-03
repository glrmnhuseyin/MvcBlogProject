using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {//Get:Category
        public IActionResult Index()
        {
            return View();
        }
    }
}
