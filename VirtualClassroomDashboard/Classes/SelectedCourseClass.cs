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
        //syllabus
        private static string SyllabusName;

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
        public static void clearCourseData()
        {
            cID = 0;
            sID = 0;
            uID = 0;
            cNam = null;
            cS = null;
            cNum = null;
            clNum = null;
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
        public static void setSyllabus(string fileName)
        {
            SyllabusName = fileName;
        }

        public static string getSyllabus()
        {
            return SyllabusName;
        }
    }
}
