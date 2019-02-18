using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using CreatePlanIntegrator = WebAPI.Integrations.CreatePlanIntegrator;
using RetrievePlanIntegrator = WebAPI.Integrations.RetrievePlanIntegrator;
using SuccessViewModel = WebAPI.Models.SuccessViewModel;

namespace WebAPI.Controllers
{
    public class PlanController : Controller
    {
        /// <summary>
        /// SHOW Plan
        /// </summary>
        /// <param name="id">plan access id</param>
        [HttpGet]
        public IActionResult Index(string id)
        {
            var resultVm = new RetrievePlanIntegrator(id).Run();
            if (resultVm is PlanViewModel planViewModel)
            {   
                return View(planViewModel);  
            }
            
            // ERROR Handling
            return View("Error", resultVm);
        }
        
        /// <summary>
        /// CREATE Plan
        /// </summary>
        [HttpPost]
        public IActionResult Index(PlanFormViewModel planFormVm)
        {
            var resultVm = new CreatePlanIntegrator(planFormVm).Run();

            if (resultVm is SuccessViewModel successViewModel)
            {
                return RedirectToAction("Success", "Plan", successViewModel);   
            }
            
            // ERROR Handling
            return View("Error", resultVm);
        }

        
        /// <summary>
        /// SHOW CREATE Form
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// SHOW Successfully-Created-Plan with access and auth links
        /// </summary>
        [HttpGet]
        public IActionResult Success(SuccessViewModel successVm)
        {
            return View(successVm);
        }
    }
}