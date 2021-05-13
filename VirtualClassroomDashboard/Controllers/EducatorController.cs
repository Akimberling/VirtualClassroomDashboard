using IdentityServer3.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Controllers
{
    public class EducatorController : Controller
    {

        private readonly ILogger<EducatorController> _logger;

        public EducatorController(ILogger<EducatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult EducatorDash()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Zoom()
        {
            return View();
        }
        public IActionResult Announcements()
        {
            return View();
        }
        public IActionResult Discussions()
        {
            return View();
        }
        public IActionResult Assignments()
        {
            return View();
        }
        public IActionResult Assessments()
        {
            return View();
        }
        public IActionResult Grades()
        {
            return View();
        }
        public IActionResult Syllabus()
        {
            return View();
        }
        public IActionResult Roster()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Account()
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
