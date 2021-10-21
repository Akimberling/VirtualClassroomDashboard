﻿using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Authorization;
using VirtualClassroomDashboard.DataLibrary.BusinessLogic;

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
                            return View("StudentDash");
                        }
                        else if (tempUserType == "teacher")
                        {
                            return View("EducatorDash");
                        }
                        else if (tempUserType == "admin")
                        {
                            return View("AdminDash");
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
            if (BasicUI["UserType"] == null)
            {

                return View("AccessDenied");

            }
            else
            {
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
        }
        [HttpPost]
        
        public IActionResult Account(UserUpdateModel model)
        {
            ViewBag.Error = "";

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            if (BasicUI["UserType"] == null)
            {

                return View("AccessDenied");

            }
            else
            {
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
                    ViewBag.Error = ViewBag.Error + " Your password has been changed.";
                }
                return View();
            }

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
            if (BasicUI["UserType"] != "Admin")
            {

                return View("AccessDenied");

            }
            else
            {
                //save the data
                TempData["FN"] = BasicUI["FirstName"];
                TempData["LN"] = BasicUI["LastName"];
                TempData["SID"] = BasicUI["SchoolID"];

                return View();
            }
        }
        
        public IActionResult AdminZoom()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            if (BasicUI["UserType"] != "Admin")
            {

                return View("AccessDenied");

            }
            else
            {
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
        }
        
        [HttpGet]
        public IActionResult ViewStudents()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            if (BasicUI["UserType"] != "Admin")
            {

                return View("AccessDenied");

            }
            else
            {
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

                return View(Students);
            }
        }
        
        public IActionResult ViewEducators()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            if (BasicUI["UserType"] != "Admin")
            {

                return View("AccessDenied");

            }
            else
            {
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

            if (BasicUI["UserType"] != "Admin")
            {

                return View("AccessDenied");

            }
            else
            {
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
        }
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult AddUsers(excelParseModel model)
        {
            ViewBag.Error = "";
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            if (BasicUI["UserType"] != "Admin")
            {

                return View("AccessDenied");

            }
            else
            {
                //    //check for duplicate users
                List<int> reocur2 = UserProcessor.CheckForDuplicates(model.FirstName, model.LastName, model.EmailAddress, model.UserType);

                if (model.UserType == "student" || model.UserType == "Student")
                {
                    model.UserType = "Student";
                }
                else if (model.UserType == "teacher" || model.UserType == "Teacher")
                {
                    model.UserType = "Teacher";
                }
                else
                {
                    ViewBag.Error = "Incorrect user type please use Student or Teacher";
                }
                if (model.UserType == "Teacher" || model.UserType == "Student")
                {
                    //if the user who is attempting to  make an account is entering in info that already exists
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
        }
        /***********************************************************************************************************
         * Student directory
         **********************************************************************************************************/
        
        public IActionResult StudentDash()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();

            if (BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else
            {
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
        }

/***********************************************************************************************************
* Educator directory
**********************************************************************************************************/
        
        public IActionResult EducatorDash()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                //save the data
                TempData["UID"] = BasicUI["UserID"];
                TempData["FN"] = BasicUI["FirstName"];
                TempData["LN"] = BasicUI["LastName"];
                TempData["PN"] = BasicUI["PhoneNumber"];
                TempData["EM"] = BasicUI["EmailAddress"];
                TempData["UT"] = BasicUI["UserType"];
                TempData["SID"] = BasicUI["SchoolID"];

                List<CourseModel> Courses = new List<CourseModel>();
                var courseData = CourseProcessor.RetrieveNecessaryCourses(userId);

                foreach (var row in courseData)
                {
                    Courses.Add(new CourseModel
                    {
                        CourseID = row.CourseID,
                        CourseName = row.CourseName,
                        CourseSection = row.CourseSection,
                        CourseNumber = row.CourseNumber,
                        ClassNum = row.ClassNum

                    });

                }
                return View(Courses);
            }
        }

        public ActionResult SetCourse(int id)
        {
            List<CourseModel> Courses = new List<CourseModel>();
            var courseData = CourseProcessor.RetrieveCourse(id);
            foreach (var row in courseData)
            {
                Courses.Add(new CourseModel
                {
                    CourseID = row.CourseID,
                    CourseName = row.CourseName,
                    CourseSection = row.CourseSection,
                    CourseNumber = row.CourseNumber,
                    ClassNum = row.ClassNum

                });
            }

            //create a new model
            CourseModel CurrentInfo = new CourseModel();

            //store the values from userData into the model
            CurrentInfo.CourseID = Courses[0].CourseID;
            CurrentInfo.CourseName = Courses[0].CourseName;
            CurrentInfo.CourseSection = Courses[0].CourseSection;
            CurrentInfo.CourseNumber = Courses[0].CourseNumber;
            CurrentInfo.ClassNum = Courses[0].CourseNumber;

            SelectedCourseClass.setCourseData(CurrentInfo);

            return View("EducatorDash");
        }
        public IActionResult TeacherZoom()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                //retrieve the necessary users and display them
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddCourse()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                TempData["EM"] = BasicUI["EmailAddress"];
                return View();
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddCourse(CourseModel model)
        {

            ViewBag.Error = "";
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                //save the data
                model.UserID = int.Parse(BasicUI["UserID"]);
                model.SchoolID = int.Parse(BasicUI["SchoolID"]);

                //check to ensure there are no dulicate courses
                List<int> uExists = CourseProcessor.CheckForDuplicates( model.CourseName, model.UserID, model.SchoolID);

                if (uExists[0] != 0)
                {
                    ViewBag.Error = "This course already exists, please try adding a different course or speak to the admin.";
                }
                else
                {
                    //Add the course information to the database
                    CourseProcessor.CreateCourse(model.SchoolID, model.UserID, model.CourseName, model.CourseSection, model.CourseNumber, model.ClassNum);
                    ViewBag.Error = "The course has been added. Please refer to the view courses page to view your courses.";
                }
                
                return View();
            }
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ViewCourses()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                List<CourseModel> Courses = new List<CourseModel>();
                var courseData = CourseProcessor.RetrieveNecessaryCourses(userId);

                foreach (var row in courseData)
                {
                    Courses.Add(new CourseModel
                    { 
                        CourseID = row.CourseID,
                        CourseName = row.CourseName,
                        CourseSection = row.CourseSection,
                        CourseNumber = row.CourseNumber,
                        ClassNum = row.ClassNum

                    });

                }

                return View(Courses);
            }
        }
        public ActionResult DeleteCourse(int id)
        {
            CourseProcessor.deleteCourseData(id);

            //check if the course exists
            List<int> cExists = CourseProcessor.CheckForDupByID(id);

            if (cExists[0] == 1)
            {
                ViewBag.Error = "Something went wrong.";
            }
            else
            {
                ViewBag.Error = "Course removed successfully.";
            }

            return View("ViewCourses");


        }
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                List<CourseModel> Courses = new List<CourseModel>();
                var courseData = CourseProcessor.RetrieveCourse(id);
                foreach (var row in courseData)
                {
                    Courses.Add(new CourseModel
                    {
                        CourseID = row.CourseID,
                        CourseName = row.CourseName,
                        CourseSection = row.CourseSection,
                        CourseNumber = row.CourseNumber,
                        ClassNum = row.ClassNum

                    });
                }
                //create a new model
                CourseModel CurrentInfo = new CourseModel();

                //store the values from userData into the model
                CurrentInfo.CourseID = Courses[0].CourseID;
                CurrentInfo.CourseName = Courses[0].CourseName;
                CurrentInfo.CourseSection = Courses[0].CourseSection;
                CurrentInfo.CourseNumber = Courses[0].CourseNumber;
                CurrentInfo.ClassNum = Courses[0].CourseNumber;

                CourseInfoClass.setTempCourseData(CurrentInfo);
                TempData["CName"] =Courses[0].CourseName;
                TempData["CN"] = Courses[0].CourseNumber;
                TempData["ClN"] = Courses[0].ClassNum;
                TempData["CSec"] = Courses[0].CourseSection;

                return View();
            }
        }
        [HttpPost]
        public IActionResult EditCourse(CourseUpdateModel model)
        {
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                Dictionary<string, string> BasicCI = new Dictionary<string, string>();
                BasicCI = CourseInfoClass.getCourseData();

                CourseProcessor.updateCourseInfo(int.Parse(BasicCI["CourseID"]), model.CourseSection, model.CourseName);

                return View("ViewCourses");
            }
        }
        [HttpGet]
        public IActionResult AddStudents(int id)
        {

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                var schoolID = int.Parse(BasicUI["SchoolID"]);

                List<UserModel> Students = new List<UserModel>();
                var userData = UserProcessor.RetrieveNecessaryUsers(schoolID, "Student");
                //user course id 

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

                List<CourseModel> Courses = new List<CourseModel>();
                var courseData = CourseProcessor.RetrieveCourse(id);

                foreach (var row in courseData)
                {
                    Courses.Add(new CourseModel
                    {
                        CourseID = row.CourseID,
                        CourseName = row.CourseName,
                        CourseSection = row.CourseSection,
                        CourseNumber = row.CourseNumber,
                        ClassNum = row.ClassNum

                    });
                }
                //create a new model
                CourseModel CurrentInfo = new CourseModel();

                //store the values from userData into the model
                CurrentInfo.CourseID = Courses[0].CourseID;
                CurrentInfo.CourseName = Courses[0].CourseName;
                CurrentInfo.CourseSection = Courses[0].CourseSection;
                CurrentInfo.CourseNumber = Courses[0].CourseNumber;
                CurrentInfo.ClassNum = Courses[0].CourseNumber;

                CourseInfoClass.setTempCourseData(CurrentInfo);
                TempData["CName"] = Courses[0].CourseName;

                return View(Students);
            }
        }
        public ActionResult AddStudent(int id)
        {
            //check to ensure there are no dulicate courses

            ViewBag.Error = "There is no action ";
            
            return View("AddStudents");
        }
        public IActionResult AccessDenied()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            return View();
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
