using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using VirtualClassroomDashboard.Models;
using VirtualClassroomDashboard.BusinessLogic;
using VirtualClassroomDashboard.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using VirtualClassroomDashboard.DataLibrary.BusinessLogic;
using System.IO;
using System.Globalization;
using System;

//HomeController
namespace VirtualClassroomDashboard.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment Environment;

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
                            return RedirectToAction("StudentDash");
                        }
                        else if (tempUserType == "teacher")
                        {
                            return RedirectToAction("EducatorDash");
                        }
                        else if (tempUserType == "admin")
                        {
                            return RedirectToAction("AdminDash");
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
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            TempData["SCI"] = "";

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

            int userId = int.Parse(BasicUI["UserID"]);
            if (BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseName"] != null)
            {
                TempData["SCI"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
                return View();
            }
            else
            {
                List<CourseModel> Courses = new List<CourseModel>();
                var courseUserData = CourseProcessor.RetrieveUserCourses(userId);

                foreach (var row in courseUserData)
                {
                    var courseData = CourseProcessor.RetrieveCoursesForUser(row.CourseID);
                    foreach(var rows in courseData)
                    {
                        Courses.Add(new CourseModel
                        {
                            CourseID = rows.CourseID,
                            CourseName = rows.CourseName,
                            CourseSection = rows.CourseSection,
                            CourseNumber = rows.CourseNumber,
                            ClassNum = rows.ClassNum

                        });
                    }
                }
                return View(Courses);
            }
        }
        public ActionResult selectStudentNewCourse()
        {
            SelectedCourseClass.clearCourseData();
            return RedirectToAction("StudentDash");
        }
        public ActionResult SetStudentCourse(int id)
        {
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

            //selected course information
            TempData["SCI"] = Courses[0].CourseName + " " + Courses[0].CourseNumber;

            SelectedCourseClass.setCourseData(CurrentInfo);
            ViewBag.Error = "You can now access your course information.";

            return View("StudentDash");
        }

        public IActionResult StudentZoom()
        {
            return View();
        }
        public IActionResult StudentAssessments()
        {

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else
            {
                return View();
            }
        }
        public IActionResult StudentAssignments()
        {

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else
            {
                return View();
            }
        }
        public IActionResult StudentGrades()
        {

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else
            {
                return View();
            }
        }
        /***********************************************************************************************************
        * Educator directory
        **********************************************************************************************************/
        [HttpGet]
        public IActionResult EducatorDash()
        {
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            TempData["SCI"] = "";

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

            int userId = int.Parse(BasicUI["UserID"]);
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseName"] != null)
            {
                TempData["SCI"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
                return View();
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
        public ActionResult selectNewCourse()
        {
            SelectedCourseClass.clearCourseData();
            return RedirectToAction("EducatorDash");
        }
        public ActionResult SetCourse(int id)
        {
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

            //selected course information
            TempData["SCI"] = Courses[0].CourseName + " " + Courses[0].CourseNumber;

            SelectedCourseClass.setCourseData(CurrentInfo);
            ViewBag.Error = "You can now access your course information.";

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
            TempData["UT"] = BasicUI["UserType"];
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
            TempData["UT"] = BasicUI["UserType"];
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
            TempData["UT"] = BasicUI["UserType"];
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
            TempData["UT"] = BasicUI["UserType"];
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
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(CourseUpdateModel model)
        {
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
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

                return RedirectToAction("ViewCourses");
            }
        }
        [HttpGet]
        public IActionResult AddStudents(int id)
        {

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            int userId = int.Parse(BasicUI["UserID"]);
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                if(id == 0)
                {
                    id = CourseInfoClass.getCourseID();
                }
                var schoolID = int.Parse(BasicUI["SchoolID"]);

                List<UserModel> Students = new List<UserModel>();
                var userData = UserProcessor.RetrieveNecessaryUsers(schoolID, "Student");

                foreach (var row in userData)
                {
                    List<int> courseCount = CourseProcessor.CheckIfUserIsInCourse(id, row.UserID);

                    if(courseCount[0] == 0)
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
                TempData["CName"] = Courses[0].CourseName;
                }
                CourseInfoClass.setCourseID(id);
                return View(Students);
            }
        }
        public ActionResult AddStudent(int id)
        {

            int cid = CourseInfoClass.getCourseID();

            CourseProcessor.AddUserToCourse(cid, id);

            return RedirectToAction("AddStudents");
        }
        public IActionResult EducatorAssessments()
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
                return View();
            }
        }
        public IActionResult EducatorAssignments()
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
                return View();
            }
        }
        public IActionResult EducatorGrades()
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
                return View();
            }
        }
        [HttpGet]
        public IActionResult EducatorSyllabus()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            int userId = int.Parse(BasicUI["UserID"]);
            TempData["UT"] = BasicUI["UserType"];
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else
            {
                TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
                string directoryName = BasicUI["FirstName"] + BasicUI["LastName"] + "_" + BasicCI["CourseNumber"];
                
                //set the path
                List<CourseFileModel> CourseFile = new List<CourseFileModel>();
                int cid = int.Parse(BasicCI["CourseID"]);
                var courseFileData = FileProcessor.RetrieveCourseFile("Syllabus", "/" + directoryName + "/", userId, cid);

                if (courseFileData.Count > 0)
                {

                    foreach (var row in courseFileData)
                    {
                        CourseFile.Add(new CourseFileModel
                        {
                            FileName = row.FileName

                        });
                    }
                    //create a new model
                    CourseFileModel fileInfo = new CourseFileModel();

                    //store the values from userData into the model
                    fileInfo.FileName = CourseFile[0].FileName;

                    System.IO.FileInfo fileP = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", directoryName + "/", fileInfo.FileName));

                    if (fileP.Exists)
                      ViewBag.Message += string.Format("<p>Current Syllabus: </p><a href= \"/" + directoryName + "/" + fileInfo.FileName + "\" target=\"_blank\" download>" + fileInfo.FileName + "</a>");
                }

                return View();
            }
        }

        [HttpPost]
        public IActionResult EducatorSyllabus(List<IFormFile> postedFiles)
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            //class Information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            int userId = int.Parse(BasicUI["UserID"]);
            string directoryName = BasicUI["FirstName"] + BasicUI["LastName"] + "_" + BasicCI["CourseNumber"];
            TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
            //form of authentication
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else if(BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else { 
                //designate the path that the file will be saved
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",  directoryName + "/");
                //check if that directory already exists. if it does create the path
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //create a list of strings called uploded files
                List<string> uploadedFiles = new List<string>();
                //foreach of the file being uploaded
                foreach (IFormFile postedFile in postedFiles)
                {
                    //grab the filename
                    string fileName = Path.GetFileName(postedFile.FileName);
                    //combine the filename with the path
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);

                    }
                    //find the file path
                    System.IO.FileInfo fi = new System.IO.FileInfo(Path.Combine(path, fileName));
                    //find the file extension
                    string fileEnd = fileName.Split(".")[1];
                    //if the file exists
                    if (fi.Exists)
                    {
                        int cid = int.Parse(BasicCI["CourseID"]);
                        //check the database
                        List<int> dupFiles = FileProcessor.CheckForDuplicates(directoryName + "." + fileEnd, userId, cid, "Syllabus");
                        //if the database contains the file
                        if(dupFiles[0] > 0)
                        {
                            //remove the file
                            int fileDel = FileProcessor.deleteCourseFileData(directoryName + "." + fileEnd, directoryName + "/", userId, cid);
                            //remove the file from server
                            System.IO.FileInfo fileP = new FileInfo(Path.Combine(path, directoryName + "." + fileEnd));
                            if (fileP.Exists)
                                fileP.Delete();
                        }
                        //change the file name
                        fi.MoveTo(Path.Combine(path, directoryName + "." + fileEnd));
                        string FilePathName = "/" + directoryName + "/" + directoryName + "." + fileEnd;

                        //inform the user that the file was uploaded and the name change
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", directoryName + "." + fileEnd);
                        ViewBag.Message += string.Format("<p>New Syllabus: </p><a href= \"" + FilePathName + "\" taget=\"_blank\" download>" + directoryName + "." + fileEnd + "</a>");
                        //set the syllabus 
                        SelectedCourseClass.setSyllabus(directoryName + "." + fileEnd);
                        string NewFile = directoryName + "." + fileEnd;
                        //save the file to the database
                        int fileRec = FileProcessor.CreateFile(NewFile, "/" + directoryName + "/", "Syllabus", directoryName + "Syllabus", userId, cid);
                    }
                    
                }
                return View();
            }
        }
        
        [HttpGet]
        public IActionResult Roster()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();

            if (BasicUI["UserType"] != "Student" && BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
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
                TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
                int courseID = int.Parse(BasicCI["CourseID"]);
                //grab user data
                List<UserModel> Students = new List<UserModel>();
                var userData = CourseProcessor.RetrieveStudentsInCourse(courseID);
                //save user data to a model
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
        public ActionResult RemoveStudent(int id)
        {
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();

            int cid = int.Parse(BasicCI["CourseID"]);
            TempData["UT"] = "Teacher";
            CourseProcessor.deleteUserFromCourse(cid, id);

            return RedirectToAction("Roster");
        }
        [HttpGet]
        public IActionResult ViewFiles()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            //save the data
            TempData["UID"] = BasicUI["UserID"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            if (BasicUI["UserType"] != "Student" && BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                
                TempData["FN"] = BasicUI["FirstName"];
                TempData["LN"] = BasicUI["LastName"];
                TempData["PN"] = BasicUI["PhoneNumber"];
                TempData["EM"] = BasicUI["EmailAddress"];
                TempData["UT"] = BasicUI["UserType"];
                TempData["SID"] = BasicUI["SchoolID"];

                var schoolID = int.Parse(BasicUI["SchoolID"]);
                TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
                int courseID = int.Parse(BasicCI["CourseID"]);
                //grab file data
                List<CourseFileModel> filesForCourse = new List<CourseFileModel>();
                var fileData = FileProcessor.RetrieveAllCourseFile(courseID);
                //save user data to a model
                foreach (var row in fileData)
                {
                    filesForCourse.Add(new CourseFileModel
                    {
                        UserID = row.UserID,
                        FileID = row.FileID,
                        CourseID = row.CourseID,
                        FileName = row.FileName,
                        FIlePath = row.FIlePath,
                        FileSubject = row.FileSubject,
                        FileDesc = row.FileDesc

                    });

                }
                return View(filesForCourse);
            }
               
        }
        public ActionResult RemoveUserFile(int id, string fname, string fpath, int cid)
        {
            //remove the file from the database
            FileProcessor.deleteCourseFileData(fname, fpath, id, cid);

            //remove the file from server
            System.IO.FileInfo fileP = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fpath, fname));

            if (fileP.Exists)
                fileP.Delete();

            return RedirectToAction("ViewFiles");
        }
        [HttpGet]
        public IActionResult CourseFiles()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            if (BasicUI["UserType"] != "Student" && BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CourseFiles(CourseFileModel model, List<IFormFile> postedFiles)
        {

            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();

            //CheckForDuplicates(string fname, int uid, int cid, string fsub)

            //check to ensure there are no dulicate courses
            List<int> fExists = FileProcessor.CheckForDuplicates(model.FileName, int.Parse(BasicUI["UserID"]), int.Parse(BasicCI["CourseID"]), model.FileSubject);

            if (fExists[0] != 0)
            {
                ViewBag.Error = "This File already exists, please try adding a different File.";
            }
            else
            {
                string directoryName = BasicUI["FirstName"] + BasicUI["LastName"] + "_" + BasicCI["CourseNumber"];
                //designate the path that the file will be saved
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", directoryName + "/");
                //check if that directory already exists. if it does create the path
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //create a list of strings called uploded files
                List<string> uploadedFiles = new List<string>();

                //foreach of the file being uploaded
                foreach (IFormFile postedFile in postedFiles)
                {
                    //grab the filename
                    string fileName = Path.GetFileName(postedFile.FileName);
                    //combine the filename with the path
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                    }
                    int cid = int.Parse(BasicCI["CourseID"]);
                    if (model.FileSubject == "Syllabus")
                    {
                        //find the file path
                        System.IO.FileInfo fi = new System.IO.FileInfo(Path.Combine(path, fileName));
                        string fileEnd = fileName.Split(".")[1];
                        //if the file exists
                        if (fi.Exists)
                        {
                            string newFile = directoryName + "." + fileEnd;
                            //change the file name
                            fi.MoveTo(Path.Combine(path, newFile));
                            //set the syllabus 
                            SelectedCourseClass.setSyllabus(newFile);

                            List<int> dupFile = FileProcessor.CheckForDuplicates(newFile, int.Parse(BasicUI["UserID"]), cid, "Syllabus");

                            if(dupFile[0] > 0)
                            {
                                //save the file to the database
                                int fileRec = FileProcessor.CreateFile(newFile, "/" + directoryName + "/", "Syllabus", directoryName + "Syllabus", int.Parse(BasicUI["UserID"]), cid);
                            }
                            else
                            {
                                FileProcessor.updateSyllabusFileInfo(newFile, "/" + directoryName + "/", int.Parse(BasicUI["UserID"]), cid);
                            }
                            
                        }
                        
                    }
                    else
                    {
                        int fileRec = FileProcessor.CreateFile(fileName, "/" + directoryName + "/", model.FileSubject, model.FileDesc, int.Parse(BasicUI["UserID"]), cid);
                    }

                }

                ViewBag.Error = "The file has been added. Please refer to the File page to view all your files.";
            }

            return RedirectToAction("ViewFiles");
        }
        [HttpGet]
        public IActionResult Announcements()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            TempData["UID"] = BasicUI["UserID"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                TempData["FN"] = BasicUI["FirstName"];
                TempData["LN"] = BasicUI["LastName"];
                TempData["PN"] = BasicUI["PhoneNumber"];
                TempData["EM"] = BasicUI["EmailAddress"];
                TempData["UT"] = BasicUI["UserType"];
                TempData["SID"] = BasicUI["SchoolID"];

                TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
                int courseID = int.Parse(BasicCI["CourseID"]);
                int userID = int.Parse(BasicUI["UserID"]);
                //grab Announcement data
                List<AnnouncementModel> announcements = new List<AnnouncementModel>();
                var AnnounceData = AnnouncementProcessor.RetrieveAllCourseAnnouncements(courseID);
                //save data to a model
                foreach (var row in AnnounceData)
                {
                    string fname = "", fpath = "";
                    if (row.FileID != 0)
                    {
                        var FileData = FileProcessor.RetrieveCourseFileByID(row.FileID);
                        foreach (var item in FileData)
                        {
                            fname = item.FileName;
                            fpath = item.FIlePath;
                        }
                    }
                    announcements.Add(new AnnouncementModel
                    {
                        
                        FileName = fname,
                        FIlePath = fpath,
                        AnnounceID = row.AnnounceID,
                        AnnounceTitle = row.AnnounceTitle,
                        AnnounceDesc = row.AnnounceDesc,
                        UserID = row.UserID,
                        FileID = row.FileID,
                        CourseID = row.CourseID,
                    });

                }
                return View(announcements);
            }
        }
        public ActionResult RemoveAnnouncement(int AnnouncID, int fileID, string fpath, string fname)
        {
            //remove announcement
            AnnouncementProcessor.deleteAnnouncement(AnnouncID);
            if(fileID != 0)
            {
                //remove the file associated with the announcement
                FileProcessor.deleteCourseFileDataByID(fileID);

                //remove the file from server
                System.IO.FileInfo fileP = new FileInfo(Path.Combine(fpath, fname));
                if (fileP.Exists)
                    fileP.Delete();
            }
            
            //redirect back to the announcements page
            return RedirectToAction("Announcements"); 
        }
        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            if (BasicUI["UserType"] != "Teacher")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnnouncement(AnnouncementModel model, List<IFormFile> postedFiles)
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            int cid = int.Parse(BasicCI["CourseID"]);
            int uid = int.Parse(BasicUI["UserID"]);
            int fid = 0;
            if (model.FileName != null)
            {

                string directoryName = BasicUI["FirstName"] + BasicUI["LastName"] + "_" + BasicCI["CourseNumber"];
                //designate the path that the file will be saved
                string path = Path.Combine(directoryName);

                //check if that directory already exists. if it does create the path
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //create a list of strings called uploded files
                List<string> uploadedFiles = new List<string>();

                //foreach of the file being uploaded
                foreach (IFormFile postedFile in postedFiles)
                {
                    //grab the filename
                    string fileName = Path.GetFileName(postedFile.FileName);
                    //combine the filename with the path
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                    }
                    
                    if (model.FileSubject == "Syllabus")
                    {
                        //find the file path
                        System.IO.FileInfo fi = new System.IO.FileInfo(Path.Combine(path, fileName));
                        string fileEnd = fileName.Split(".")[1];
                        //if the file exists
                        if (fi.Exists)
                        {
                            string newFile = directoryName + "." + fileEnd;
                            //change the file name
                            fi.MoveTo(Path.Combine(path, newFile));
                            //set the syllabus 
                            SelectedCourseClass.setSyllabus(newFile);
                            //save the file to the database
                            int fileRec = FileProcessor.CreateFile(newFile, path + "/", "Syllabus", directoryName + "Syllabus", uid, cid);
                        }
                    }
                    else
                    {
                        int fileRec = FileProcessor.CreateFile(fileName, path + "/", model.FileSubject, model.FileDesc, int.Parse(BasicUI["UserID"]), cid);

                    }
                    //grab file data
                    var finfo = FileProcessor.RetrieveCourseFile(model.FileSubject, path + "/", uid, cid);

                    foreach (var row in finfo)
                    {
                        fid = row.FileID;
                    }
                }
            }

            int announceRec = AnnouncementProcessor.CreateAnnouncement(model.AnnounceTitle, model.AnnounceDesc, cid, uid,fid);

            return RedirectToAction("Announcements");
        }
        [HttpGet]
        public IActionResult Discussions()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            TempData["UT"] = BasicUI["UserType"];
            TempData["UID"] = BasicUI["UserID"];
            TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
            int cid = int.Parse(BasicCI["CourseID"]);
            //grab daved information
            
            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                List<DiscussionsModel> discuss = new List<DiscussionsModel>();
                var DiscussData = DiscussionProcessor.RetrieveDiscussionsForCourse(cid);
                //save data to a model
                foreach (var row in DiscussData)
                {
                    discuss.Add(new DiscussionsModel
                    {
                        DiscussionID = row.DiscussionID,
                        DiscussionTitle = row.DiscussionTitle
                    });
                }
                return View(discuss);
            }
        }
        [HttpGet]
        public IActionResult AddDiscussion()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //grab saved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
            TempData["UT"] = BasicUI["UserType"];

            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {
                return View("AccessDenied");
            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDiscussion(DiscussionsModel model)
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //grab saved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();

            TempData["UT"] = BasicUI["UserType"];
            TempData["UID"] = BasicUI["UserID"];
            int cid = int.Parse(BasicCI["CourseID"]);
            int uid = int.Parse(BasicUI["UserID"]);

            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {
                return View("AccessDenied");
            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                string date = DateTime.Now.ToString();
                date = date.Split(' ')[0];
                int temp = DiscussionProcessor.CreateDiscussion(uid, cid, model.DiscussionTitle, model.DiscussionDesc, date);
                return RedirectToAction("Discussions");
            }
        }
        public IActionResult Discussion(int id)
        {
            if(id == 0)
            {
                id = setDiscussionClass.geDiscussData();
            }
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            TempData["UT"] = BasicUI["UserType"];
            TempData["UID"] = BasicUI["UserID"];
            TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                TempData["CourseName"] = BasicCI["CourseName"];
                var DiscussData = DiscussionProcessor.RetrieveDiscussionForCourse(id);

                ViewData["DiscussionTitle"] = DiscussData[0].DiscussionTitle;
                ViewData["DiscussionDesc"] = DiscussData[0].DiscussionDesc;
                ViewData["DiscussionDate"] = DiscussData[0].DiscussionDate.Split(' ')[0];

                setDiscussionClass.setDiscussData(id);
                List<DiscussionReplyModel> dRep = new List<DiscussionReplyModel>();
                var DiscussRepData = DiscussionReplyProcessor.RetrieveDiscussionRepliesForCourse(id);
                //save data to a model
                foreach (var row in DiscussRepData)
                {
                    dRep.Add(new DiscussionReplyModel
                    {
                        DiscussionReplyID = row.DiscussionReplyID,
                        DiscussionReplyDesc = row.DiscussionReplyDesc,
                        DiscussionReplyDate = row.DiscussionReplyDate.Split(' ')[0],
                        UserID = row.UserID,
                        UserName = row.UserName

                    });
                }

                return View(dRep);
            }
        }
        [HttpGet]
        public IActionResult DiscussionReply(int id)
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();
            TempData["UT"] = BasicUI["UserType"];
            TempData["UID"] = BasicUI["UserID"];
            TempData["CourseName"] = BasicCI["CourseName"] + " " + BasicCI["CourseNumber"];
            
            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                id = setDiscussionClass.geDiscussData();
                TempData["CourseName"] = BasicCI["CourseName"];
                var DiscussData = DiscussionProcessor.RetrieveDiscussionForCourse(id);

                //save data to a model
                foreach (var row in DiscussData)
                {
                    ViewData["DiscussionTitle"] = row.DiscussionTitle;
                    ViewData["DiscussionDesc"] = row.DiscussionDesc;
                    ViewData["DiscussionDate"] = row.DiscussionDate.Split(' ')[0];
                }

                return View();


            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DiscussionReply(DiscussionReplyModel model)
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];
            TempData["UID"] = BasicUI["UserID"];
            //grab daved information
            Dictionary<string, string> BasicCI = new Dictionary<string, string>();
            BasicCI = SelectedCourseClass.getCourseData();

            int cid = int.Parse(BasicCI["CourseID"]);
            int uid = int.Parse(BasicUI["UserID"]);

            if (BasicUI["UserType"] != "Teacher" && BasicUI["UserType"] != "Student")
            {

                return View("AccessDenied");

            }
            else if (BasicCI["CourseNumber"] == null)
            {
                ViewBag.Message = "Please go to the Dashboard and Select a Course. There is no active course selected.";
                return View();
            }
            else
            {
                int did = setDiscussionClass.geDiscussData();
                string date = DateTime.Now.ToString();
                date = date.Split(' ')[0];
                int temp = DiscussionReplyProcessor.CreateDiscussionReply(uid,did, model.DiscussionReplyDesc, date);
                return RedirectToAction("Discussion", did);
            }
        }
        public IActionResult RemoveDiscussion(int id)
        {
            int temp = DiscussionProcessor.deleteDiscussions(id);
            return RedirectToAction("Discussions");
        }
        public IActionResult AccessDenied()
        {
            //establish a dictionary that will contain user information that was set during login
            Dictionary<string, string> BasicUI = new Dictionary<string, string>();
            BasicUI = UserInfoClass.getUserData();
            TempData["UT"] = BasicUI["UserType"];

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
