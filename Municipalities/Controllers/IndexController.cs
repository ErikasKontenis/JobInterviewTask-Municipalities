using Microsoft.AspNetCore.Mvc;

namespace Municipalities.Controllers
{
    public class IndexController : Controller
    {
        public IndexController()
        { }

        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
