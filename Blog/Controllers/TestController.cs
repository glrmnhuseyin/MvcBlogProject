using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
