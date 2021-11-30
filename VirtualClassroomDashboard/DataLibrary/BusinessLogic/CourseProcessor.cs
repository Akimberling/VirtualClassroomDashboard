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
        public static int AddUserToCourse(int cid, int uID)
        {
            CourseModelData data = new CourseModelData
            {
                CourseID = cid,
                UserID = uID,

            };

            string sql = @"INSERT INTO dbo.USER_COURSE (UserID, CourseID) VALUES (@UserID, @CourseID);";

            return sqlDataAccess.SaveData(sql, data);

        }
        //retrieve the user course ID's -- Needed for studcent dash
        public static List<CourseModelData> RetrieveUserCourses(int UID)
        {
            string sql = "SELECT * FROM dbo.USER_COURSE WHERE UserID = \'" + UID + "\';";

            return sqlDataAccess.LoadData<CourseModelData>(sql);
        }
        //retrieve the courses the user is in by the course ids from Retrieve User courses --  Needed for studcent dash
        public static List<CourseModelData> RetrieveCoursesForUser(int CID)
        {
            string sql = "SELECT * FROM dbo.COURSES WHERE CourseID = \'" + CID + "\';";

            return sqlDataAccess.LoadData<CourseModelData>(sql);
        }
        public static int deleteUserFromCourse(int cid, int uID)
        {
            CourseModelData data = new CourseModelData
            {
                CourseID = cid,
                UserID = uID,
            };
            string sql = "DELETE FROM dbo.USER_COURSE WHERE CourseID = @CourseID AND UserID = @UserID;";

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
            string sql = "SELECT CourseID FROM dbo.COURSES WHERE UserID = \'" + userID + "\' AND CourseName = \'" + cName + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        public static int addStudents(int courseID, int userID)
        {
            CourseModelData data = new CourseModelData { };

            string sql = @"INSERT INTO dbo.USER_COURSES (UserID, CourseID) VALUES (\'" + courseID + "\', \'" + userID + "\'); ";

            return sqlDataAccess.SaveData(sql, data);
        }
        public static List<int> CheckForExistingStudent(int courseID, int userID)
        {
            string sql = "SELECT COUNT(*) FROM dbo.USER_COURSES WHERE CourseID = \'" + courseID + "AND UserID = \'" + userID + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        public static List<UserModelData> RetrieveStudentsInCourse(int courseId)
        {
            string sql = "SELECT * FROM dbo.USER_INFO INNER JOIN USER_COURSE ON dbo.USER_INFO.UserID = dbo.USER_COURSE.UserID WHERE dbo.USER_COURSE.CourseID = \'" + courseId + "\';";

            return sqlDataAccess.LoadData<UserModelData>(sql);
        }

    }
}
