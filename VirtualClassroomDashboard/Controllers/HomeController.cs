using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using VirtualClassroomDashboard.Models;
using VirtualClassroomDashboard.BusinessLogic;
using VirtualClassroomDashboard.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using Grpc.Core;

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

                    //var userSchoolData;

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


                        //set the data into a class so it can be accessed anywhere
                    UserInfoClass.setUserData(UserInfo);

                        //safety case for accessing the data initially
                    TempData["UID"] = UserInfo.UserID;
                    TempData["FN"] = UserInfo.FirstName;
                    TempData["LN"] = UserInfo.LastName;
                    TempData["PN"] = UserInfo.PhoneNumber;
                    TempData["EM"] = UserInfo.EmailAddress;
                    TempData["UT"] = UserInfo.UserType;
                    TempData["SID"] = UserInfo.SchoolID;

                    //verify that the passwords match, if not let the user know that the password was incorrect.
                    if (!PasswordClass.VerifyPassword(model.UserPassword, UserInfo.Password, UserInfo.Salt))
                    {
                        ViewBag.Error = "Incorrect Password.";
                    }
                    else
                    {
                        string tempUserType = UserInfo.UserType.ToLower();
                       
                        //based on the users type send them to the proper dashboard
                        if (tempUserType == "student")
                        {
                            return View("StudentDash", UserInfo);
                        }
                        else if (tempUserType == "teacher")
                        {
                            return View("EducatorDash", UserInfo);
                        }
                        else if (tempUserType == "admin")
                        {
                            return View("AdminDash", UserInfo);
                        }
                        else
                        {
                            ViewBag.Error = "User type is not set correctly.";
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
                    List<int> reocur2 = UserProcessor.CheckForDuplicates(model.FirstName, model.LastName, model.EmailAddress, "");
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

                        return View("Login");
                    }
                    
                }
                
            }
            return View();
        }
        [HttpGet]
        public IActionResult Documentation()
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
        public IActionResult Account()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

            return View();
        }
        [HttpPost]
        public IActionResult Account(UserUpdateModel model)
        {
            ViewBag.Error = "";

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

            int userID = int.Parse(BasicUI["UserID"]);
            if (model.PhoneNumber != null)
            {
                UserProcessor.updateUserPhoneNumber(model.PhoneNumber, userID);
                ViewBag.Error = "Your phone number has been updated.";
            }

            if (model.Password != null)
            {
                //generate the salt value
                string salt = PasswordClass.SaltGeneration();
                //ecncrypt password
                string hashedPass = PasswordClass.HashPassword(salt, model.Password);
                UserProcessor.updateUserPassword(hashedPass, salt, userID);
                ViewBag.Error = ViewBag.Error +  " Your password has been changed.";
            }
            return View();

        }
        [HttpGet]
        public IActionResult ContactConfirmation()
        {
            return View();
        }

/***********************************************************************************************************
 * Admin directory
 **********************************************************************************************************/

        public IActionResult AdminDash()
        {
                //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["SID"] = BasicUI["SchoolID"];

            return View();
        }
        public IActionResult AdminZoom()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

            var schoolID = int.Parse(BasicUI["SchoolID"]);

            List<UserModel> Students = new List<UserModel>();
            var userData = UserProcessor.RetrieveNecessaryUsers(schoolID, "Student");

            foreach (var row in userData)
            {
                Students.Add(new UserModel
                {
                    UserID = row.UserID,
                    FirstName = row.UserFname,
                    LastName = row.UserLname,
                    EmailAddress = row.UserEmail,
                    PhoneNumber = row.UserPhonNum,

                });

            }
            return View();
        }
        [HttpGet]
        public IActionResult ViewStudents()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];
            
            var schoolID = int.Parse(BasicUI["SchoolID"]);

            List<UserModel> Students = new List<UserModel>();
            var userData = UserProcessor.RetrieveNecessaryUsers(schoolID, "Student");

            foreach(var row in userData)
            {
                Students.Add(new UserModel
                {
                    UserID = row.UserID,
                    FirstName = row.UserFname,
                    LastName = row.UserLname,
                    EmailAddress = row.UserEmail,
                    PhoneNumber = row.UserPhonNum,

                });
                
            }

            return View(Students);
        }
     
        public IActionResult ViewEducators()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

            var schoolID = int.Parse(BasicUI["SchoolID"]);

            List<UserModel> Educators = new List<UserModel>();
            var userData = UserProcessor.RetrieveNecessaryUsers(schoolID, "Teacher");

            foreach (var row in userData)
            {
                Educators.Add(new UserModel
                {
                    UserID = row.UserID,
                    FirstName = row.UserFname,
                    LastName = row.UserLname,
                    EmailAddress = row.UserEmail,
                    PhoneNumber = row.UserPhonNum,

                });

            }

            return View(Educators);
        }
        public ActionResult DeleteStudent(int id)
        {
            UserProcessor.deleteUserData(id);
            //inform user that
           

            //check if the user exists
            List<int> uExists = UserProcessor.CheckForExistingAccountByID(id);

            if (uExists[0] == 1)
            {
                ViewBag.Error = "Something went wrong.";           
            }
            else
            {
                ViewBag.Error = "User removed successfully.";
            }

            return View("ViewStudents");


        }

        public ActionResult DeleteEducators(int id)
        {
            UserProcessor.deleteUserData(id);
            //inform user that


            //check if the user exists
            List<int> uExists = UserProcessor.CheckForExistingAccountByID(id);

            if (uExists[0] == 1)
            {
                ViewBag.Error = "Something went wrong.";
            }
            else
            {
                ViewBag.Error = "User removed successfully.";
            }

            return View("ViewEducators");


        }
        [HttpGet]
        public IActionResult AddUsers()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

            var schoolID = int.Parse(BasicUI["SchoolID"]);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUsers(excelParseModel model)
        {
            ViewBag.Error = "";
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //    //check for duplicate users
            List<int> reocur2 = UserProcessor.CheckForDuplicates(model.FirstName, model.LastName, model.EmailAddress,model.UserType);

            if(model.UserType == "student" || model.UserType == "Student")
            {
                model.UserType = "Student";
            }
            else if(model.UserType == "teacher" || model.UserType == "Teacher")
            {
                model.UserType = "Teacher";
            }
            else {
                    ViewBag.Error = "Incorrect user type please use Student or Teacher";
            }
            if (model.UserType == "Teacher" || model.UserType == "Student")
            {
                //    //if the user who is attempting to  make an account is entering in info that already exists
                if (reocur2[0] > 0)
                {
                    //inform user that
                    ViewBag.Error = "This account already exists. Either Login or enter new credentials.";
                }
                else
                {
                    model.Password = "johnDoe3#";
                    //generate the salt value
                    string salt = PasswordClass.SaltGeneration();
                    //ecncrypt password
                    string hashedPass = PasswordClass.HashPassword(salt, model.Password);
                    //create a new user with the information from above
                    int userRec = UserProcessor.CreateUser(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress, hashedPass, salt, model.UserType, int.Parse(BasicUI["SchoolID"]));
                    ViewBag.Error = "Congratualations You have added a " + model.UserType;
                }
            }
            ModelState.Clear();
            return View();
        }
        /***********************************************************************************************************
         * Student directory
         **********************************************************************************************************/

        public IActionResult StudentDash()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

            return View();
        }

/***********************************************************************************************************
* Educator directory
**********************************************************************************************************/

        public IActionResult EducatorDash()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            //save the data
            TempData["UID"] = BasicUI["UserID"];
            TempData["FN"] = BasicUI["FirstName"];
            TempData["LN"] = BasicUI["LastName"];
            TempData["PN"] = BasicUI["PhoneNumber"];
            TempData["EM"] = BasicUI["EmailAddress"];
            TempData["UT"] = BasicUI["UserType"];
            TempData["SID"] = BasicUI["SchoolID"];

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
