using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class PlanController : Controller
    {
        /// <summary>
        /// SHOW CREATE Form
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// SHOW CREATE Form
        /// </summary>
        [HttpPost]
        public IActionResult Index()
        {
            //TODO 1: insert the new plan in the DB
            
            //TODO 2: extract the plan id and forward it to the success-page

            return RedirectToRoute("Default",
                new {controller = "Plan", action = "Success"});
        }
        
        /// <summary>
        /// SHOW Plan
        /// </summary>
        /// <param name="id">plan access id</param>
        [HttpGet]
        public IActionResult Index(string id)
        {
            return View();
        }

        /// <summary>
        /// SHOW Successfully-Created-Plan with access and auth links
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authToken"></param>
        [HttpGet]
        public IActionResult Success(string id, string authToken)
        {
            return View();
        }
    }
}