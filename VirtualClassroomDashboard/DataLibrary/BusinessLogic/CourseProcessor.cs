using VirtualClassroomDashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;

namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class CourseProcessor
    {
        public static int CreateCourse(int sID, int uID, string courseNam, string courseS, string courseNum, string clNum)
        {
            CourseModelData data = new CourseModelData {
                CourseID = 0,
                SchoolID = sID,
                UserID = uID,
                CourseName = courseNam,
                CourseSection = courseS,
                CourseNumber = courseNum,
                ClassNum = clNum

            };

            string sql = @"INSERT INTO dbo.COURSES (CourseID, CourseName, CourseSection, CourseNumber, ClassNum, UserID, SchoolID) VALUES (@CourseID, @CourseName, @CourseSection, @CourseNumber, @ClassNum, @UserID, @SchoolID);";

            return sqlDataAccess.SaveData(sql, data);

        }
        public static List<int> CheckForDuplicates(string CourseName, int UID, int SID)
        {
            string sql = "SELECT COUNT(*) FROM dbo.COURSES WHERE CourseName = \'" + CourseName + "\' AND UserID = \'" + UID + "\' AND SchoolID = \'" + SID + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        public static List<int> CheckForDupByID(int CourseID)
        {
            string sql = "SELECT COUNT(*) FROM dbo.COURSES WHERE CourseID = \'" + CourseID + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        public static int deleteCourseData(int courseID)
        {
            CourseModelData data = new CourseModelData
            {
                CourseID = courseID
            };
            string sql = "DELETE FROM dbo.COURSES WHERE CourseID = @CourseID;";

            return sqlDataAccess.SaveData(sql, data);
        }
        public static int updateCourseInfo(int courseID, string courseS, string courseNam)
        {
            CourseModelData data = new CourseModelData
            {
                CourseID = courseID,
                CourseName = courseNam,
                CourseSection = courseS
            };
            if(courseNam == null)
            {
                string sql = "UPDATE dbo.COURSES SET CourseSection = @CourseSection WHERE CourseID = @CourseID;";
                return sqlDataAccess.SaveData(sql, data);
            }
            else if (courseS == null)
            {
                string sql = "UPDATE dbo.COURSES SET CourseName = @CourseName WHERE CourseID = @CourseID;";
                return sqlDataAccess.SaveData(sql, data);
            }
            else
            {
                string sql = "UPDATE dbo.COURSES SET CourseName = @CourseName, CourseSection = @CourseSection WHERE CourseID = @CourseID;";
                return sqlDataAccess.SaveData(sql, data);
            }
        }
        public static List<CourseModelData> RetrieveNecessaryCourses(int UID)
        {
            string sql = "SELECT * FROM dbo.COURSES WHERE UserID = \'" + UID + "\';";

            return sqlDataAccess.LoadData<CourseModelData>(sql);
        }
        public static List<CourseModelData> RetrieveCourse(int courseId)
        {
            string sql = "SELECT * FROM dbo.COURSES WHERE CourseID = \'" + courseId + "\';";

            return sqlDataAccess.LoadData<CourseModelData>(sql);
        }
        public static List<int> getCourseData(int userID, string cName)
        {
            string sql = "SELECT CourseID FROM dbo.COURSES WHERE UserID = \'" + userID + "\' CourseName = \'" + cName + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
    }
}
