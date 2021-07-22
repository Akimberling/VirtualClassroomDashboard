using VirtualClassroomDashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroomDashboard.DataAccess;

namespace VirtualClassroomDashboard.BusinessLogic
{
    public static class UserProcessor
    {
            //Add users to the database
        public static int CreateUser(string firstName, string lastName, string phoneNumber, string email, string password, string salt, string userType, int schoolId)
        {
                //The default when registering should mean that the user is an Admin for the school
            if (userType == "")
                userType = "Admin";

            UserModelData data = new UserModelData
            {
                UserID = 0,
                UserFname = firstName,
                UserLname = lastName,
                UserPhonNum = phoneNumber,
                UserEmail = email,
                UserPassword = password,
                UserSalt = salt,
                UserType = userType,
                SchoolID = schoolId
            };

            string sql = @"INSERT INTO dbo.USER_INFO (UserID, UserFname, UserLname, UserPhonNum, UserEmail, UserPassword, UserSalt, UserType, SchoolID) VALUES (@UserID, @UserFname, @UserLname, @UserPhonNum, @UserEmail, @UserPassword, @UserSalt, @UserType, @SchoolID)";

            return sqlDataAccess.SaveData(sql, data);

        }
            //Check to see if the data being entered already exists in the database
        public static List<int> CheckForDuplicates(string firstName, string lastName,  string email, string userType)
        {
            if (userType == "")
                userType = "Admin";

            string sql = "SELECT COUNT(*) FROM dbo.USER_INFO WHERE UserFname = \'" + firstName + "\' AND UserLname = \'" + lastName + "\' AND UserEmail = \'" + email + "\' AND UserType = \'" + userType + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
            //Check to see if the user exists
        public static List<int> CheckForExistingAccount(string email)
        {
            string sql = "SELECT COUNT(*) FROM dbo.USER_INFO WHERE UserEmail = \'" + email + "\';";
            return sqlDataAccess.LoadData<int>(sql);
        }
            //retrieve a single users information
        public static List<UserModelData> RetrieveUserInfo(string email)
        {
            string sql = "SELECT * FROM dbo.USER_INFO WHERE UserEmail = \'" + email + "\';";

            return sqlDataAccess.LoadData<UserModelData>(sql);
        }
            //Select all users that are from a given school with the specified user type
        public static List<UserModelData> RetrieveNecessaryUsers(int schoolId, string userType)
        {
            string sql = "SELECT * FROM dbo.USER_INFO WHERE SchoolID = \'" + schoolId + "\' AND USerType = \'" + userType + "\';";

            return sqlDataAccess.LoadData<UserModelData>(sql);
        }
    }
}
