using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using VirtualClassroomDashboard.Models;
using DataLibrary.BusinessLogic;
using VirtualClassroomDashboard.Classes;

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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserSignInModel model)
        {
            if (ModelState.IsValid)
            {

                    //check if the user exists
                List<int> uExists = UserProcessor.CheckForExistingAccount(model.UserEmail);

                    //if they don't warn the user the account does not exists
                if (uExists[0] == 0)
                {
                    ViewBag.Error = "There is no existing account for the email you entered. Please register or check the information you entered.";
                }
                else
                {
                        //collect data from db
                    var userData = UserProcessor.RetrieveUserInfo(model.UserEmail);
                        //create a new model
                    UserModel UserInfo = new UserModel();

                        //store the values from userData into the model
                    foreach (var row in userData)
                    {
                        UserInfo.UserID = row.UserID;
                        UserInfo.FirstName = row.UserFname;
                        UserInfo.LastName = row.UserLname;
                        UserInfo.PhoneNumber = row.UserPhonNum;
                        UserInfo.EmailAddress = row.UserEmail;
                        UserInfo.Password = row.UserPassword;
                        UserInfo.Salt = row.UserSalt;
                        UserInfo.UserType = row.UserType;
                        UserInfo.SchoolID = row.SchoolID;
                    }
                    
                        //verify that the passwords match, if not let the user know that the password was incorrect.
                    if(!PasswordClass.VerifyPassword(model.UserPassword, UserInfo.Password, UserInfo.Salt))
                    {
                        ViewBag.Error = "Incorrect Password.";
                    }
                    else
                    {
                            //based on the users type send them to the proper dashboard
                        if (UserInfo.UserType == "Student" || UserInfo.UserType == "student")
                        {
                            return RedirectToAction("StudentDash", "Student", UserInfo);
                        }
                        else if (UserInfo.UserType == "Educator" || UserInfo.UserType == "educator")
                        {
                            return RedirectToAction("EducatorDash", "Educator", UserInfo);
                        }
                        else
                        {
                            return RedirectToAction("AdminDash", "Admin", UserInfo);
                        }
                    }
                    
                }
            }
            return View();
        }
        [HttpGet]
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
                    //check if there are any current occurences of the school info that is attempting to be added
                List<int> reocur = SchoolProcessor.CheckForDuplicates(model.SchoolName, model.SchoolLevel, model.SchoolCity, model.SchoolState);
                    //if the number of reocurences are greater then 0, inform user
                if(reocur[0] > 0)
                {
                    ViewBag.Error = "This school already exists under another account.";
                }
                else
                {
                        //check for duplicate users
                    List<int> reocur2 = UserProcessor.CheckForDuplicates(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress, "");
                        //if the user who is attempting to  make an account is entering in info that already exists
                    if (reocur2[0] > 0)
                    {
                            //inform user that
                        ViewBag.Error = "This account already exists. Either Login or enter new credentials.";
                    }
                    else
                    {
                            //generate the salt value
                        string salt = PasswordClass.SaltGeneration();
                            //ecncrypt password
                        string hashedPass = PasswordClass.HashPassword(salt, model.Password);

                            //create a new school
                        int schoolRec = SchoolProcessor.CreateSchool(model.SchoolName, model.SchoolLevel, model.SchoolCity, model.SchoolState);
                            //get the school id from the newly entered information
                        List<int> schoolID = SchoolProcessor.GetSchoolID(model.SchoolName);
                            //create a new user with the information from above
                        int userRec = UserProcessor.CreateUser(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress, hashedPass, salt, "", schoolID[0]);
                            //redirect to the admin dash becuase a member who registers should be an admin
                        return RedirectToAction("AdminDash", "Admin"); 
                    }
                    
                }
                
            }
            return View();
        }
        [HttpGet]
        public IActionResult Manual()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                string name = model.fName + " " + model.lName;
                ViewData["UserName"] = name;

                ContactEmailClass.sendEmail(name, model.email, model.comments);
                ContactEmailClass.reponseEmail(name, model.email);

                return View("ContactConfirmation");
            }
            return View();

        }
        [HttpGet]
        public IActionResult ContactConfirmation()
        {
            return View();
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
