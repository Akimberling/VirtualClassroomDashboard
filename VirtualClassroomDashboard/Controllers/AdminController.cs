using IdentityServer3.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroomDashboard.Models;
using VirtualClassroomDashboard.BusinessLogic;
using VirtualClassroomDashboard.Classes;
using ErrorViewModel = IdentityServer3.Core.ViewModels.ErrorViewModel;

namespace VirtualClassroomDashboard.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AdminDash()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminDash(UserModel UserInfo)
        {
            ViewBag.userId = UserInfo.UserID;
            ViewBag.firstN = UserInfo.FirstName;
            ViewBag.lastN = UserInfo.LastName;
            ViewBag.phoneN = UserInfo.PhoneNumber;
            ViewBag.emailA = UserInfo.EmailAddress;
            ViewBag.userT = UserInfo.UserType;
            ViewBag.schoolId = UserInfo.SchoolID;

            return View();
        }
        public IActionResult Schools()
        {
            return View();
        }
        public IActionResult Zoom()
        {
            return View();
        }
        public IActionResult Students()
        {
            return View();
        }
        public IActionResult Educators()
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
