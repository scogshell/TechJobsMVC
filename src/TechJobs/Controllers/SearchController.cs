using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> Jobs;
            if (searchType.Equals("All"))
            {
                 Jobs = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                
                

            }
            else
            {
                Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.colulmns = ListController.columnChoices;
                ViewBag.jobs = Jobs;
            }
            ViewBag.jobs = Jobs;
            return View("Index");
        }
    }
}
