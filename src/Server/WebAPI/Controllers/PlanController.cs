using System;
using AppDomain.Requests;
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
            if (resultVm is PlanFormViewModel planViewModel)
            {   
                return View(new PlanViewModel
                {
                    Title = "Dummy Title",
                    Description = "Dummy Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum ",
                    Chores = new []{
                        new ChoreViewModel
                        {
                            Title = "Wash Dishes",
                            CurrentAssignee = "Peta",
                            NextAssignee = "H-Olga aka. Holgar d. Schreckliche",
                            Description = "Immer schön mit dem Pril waschen und dabei net vom Frühstück naschen!",
                            Start = DateTime.Now,
                            End = DateTime.Now
                        }
                    }
                });  
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
            var intervalTypes = IntervalService.GetIntervalFriendlyNames();
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