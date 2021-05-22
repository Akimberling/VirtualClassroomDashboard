using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(string firstName, string lastName, string phoneNumber, string email, string password, string salt, string userType, int schoolId)
        {
                //The default when registering should mean that the user is an Admin for the school
            if (userType == "")
                userType = "Admin";

            UserModel data = new UserModel
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
        public static List<int> CheckForDuplicates(string firstName, string lastName, string phoneNumber, string email, string userType)
        {
            if (userType == "")
                userType = "Admin";

            string sql = "SELECT COUNT(*) FROM dbo.USER_INFO WHERE UserFname = \'" + firstName + "\' AND UserLname = \'" + lastName + "\' AND UserPhonNum = \'" + phoneNumber + "\' AND UserEmail = \'" + email + "\' AND UserType = \'" + userType + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }

        public static List<int> CheckForExistingAccount(string email)
        {
            string sql = "SELECT COUNT(*) FROM dbo.USER_INFO WHERE UserEmail = \'" + email + "\';";
            return sqlDataAccess.LoadData<int>(sql);
        }
        public static List<UserModel> RetrieveUserInfo(string email)
        {
            string sql = "SELECT * FROM dbo.USER_INFO WHERE UserEmail = \'" + email + "\';";

            return sqlDataAccess.LoadData<UserModel>(sql);
        }
    }
}
