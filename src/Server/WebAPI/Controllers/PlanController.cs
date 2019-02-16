using System.Collections.Generic;
using AppDomain.Requests;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using CreatePlanIntegrator = WebAPI.Integrations.CreatePlanIntegrator;
using PlanViewModel = WebAPI.Models.PlanViewModel;
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
            return RedirectToAction("Index", "Home");
        }
        
        /// <summary>
        /// CREATE Plan
        /// </summary>
        [HttpPost]
        public IActionResult Index(PlanViewModel planVM)
        {
            var resultVm = new CreatePlanIntegrator(planVM).Run();

            if (resultVm is SuccessViewModel successViewModel)
            {
                return RedirectToAction("Success", "Plan", successViewModel);   
            }
            
            // ERROR Handling
            return RedirectToAction("Index", "Home");
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