using Microsoft.AspNetCore.Mvc;

namespace EduPost.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult LandingPage()
        {
            return View();
        }
    }
}
