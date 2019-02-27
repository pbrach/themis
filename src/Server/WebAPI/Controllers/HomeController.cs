using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ErrorViewModel = WebAPI.Models.ErrorViewModel;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ids = new PlanRepository().GetAccessInfos();
            return View(ids);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}