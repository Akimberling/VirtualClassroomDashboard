using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroomDashboard.Models;

namespace VirtualClassroomDashboard.Classes
{
    public class SelectedCourseClass
    {
        //courseID
        private static int cID;
        //schoolID
        private static int sID;
        //userID - teacher
        private static int uID;
        //courseName
        private static string cNam;
        //courseSection
        private static string cS;
        //courseNumber
        private static string cNum;
        //classNum
        private static string clNum;

        public static void setCourseData(CourseModel model)
        {
            cID = model.CourseID;
            sID = model.SchoolID;
            uID = model.UserID;
            cNam = model.CourseName;
            cS = model.CourseSection;
            cNum = model.CourseNumber;
            clNum = model.ClassNum;
        }
        public static Dictionary<string, string> getCourseData()
        {
            //basic course info
            Dictionary<string, string> BCI = new Dictionary<string, string>();
            BCI.Add("CourseID", cID.ToString());
            BCI.Add("SchoolID", sID.ToString());
            BCI.Add("UserID", uID.ToString());
            BCI.Add("CourseName", cNam);
            BCI.Add("CourseSection", cS);
            BCI.Add("CourseNumber", cNum);
            BCI.Add("ClassNum", clNum);

            return BCI;
        }
    }
}
