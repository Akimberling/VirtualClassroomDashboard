using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroomDashboard.Models;
using DataLibrary.BusinessLogic;


//HomeController
namespace VirtualClassroomDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(UserModel model)
        {

            if (ModelState.IsValid)
            {
                //This should all be moved to a seperate file later
                List<int> reocur = SchoolProcessor.CheckForDuplicates(model.SchoolName, model.SchoolLevel, model.SchoolCity, model.SchoolState);

                if(reocur[0] > 0)
                {
                   //Figure out how to notify that there is an error
                }
                else
                {
                    List<int> reocur2 = UserProcessor.CheckForDuplicates(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress, "");
                    if (reocur2[0] > 0)
                    {
                        //Figure out how to notify that there is an error
                    }
                    else
                    {
                        int schoolRec = SchoolProcessor.CreateSchool(model.SchoolName, model.SchoolLevel, model.SchoolCity, model.SchoolState);
                        List<int> schoolID = SchoolProcessor.GetSchoolID(model.SchoolName);
                        int userRec = UserProcessor.CreateUser(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress, "", schoolID[0]);
                        //change this later to redirect to the admin home page
                        return RedirectToAction("Index");
                    }
                    
                }
                
            }
            return View();
        }
        public IActionResult Manual()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
