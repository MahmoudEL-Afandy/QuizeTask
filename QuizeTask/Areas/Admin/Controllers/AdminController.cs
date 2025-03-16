using Microsoft.AspNetCore.Mvc;

namespace QuizeTask.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
