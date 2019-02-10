using domain;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

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
        [ValidateAntiForgeryToken]
        public IActionResult Index(PlanViewModel planVM)
        {
            var plandBuidler = new PlanRepository();
            var planAdress = plandBuidler.CreatePlan(planVM);

            return RedirectToRoute("Default",new
            {
                controller = "Plan", 
                action = "Success", 
                id=planAdress.Item1, 
                authToken=planAdress.Item2
            });
        }
        
        /// <summary>
        /// SHOW Plan
        /// </summary>
        /// <param name="id">plan access id</param>
        [HttpGet]
        public IActionResult Index(string id)
        {
            var planRepo = new PlanRepository();
            var plan = planRepo.GetPlan(id);
            
            return View(new PlanViewModel
            {
                Title = plan.Title,
                Description = plan.Description
            });
        }

        /// <summary>
        /// SHOW Successfully-Created-Plan with access and auth links
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authToken"></param>
        [HttpGet]
        public IActionResult Success(string id, string authToken)
        {
            ViewBag.accessId = id;
            ViewBag.authToken = authToken;
            return View();
        }
    }
}