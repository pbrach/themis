using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class PlanController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}