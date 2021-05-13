using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(string firstName, string lastName, string phoneNumber, string email, string userLevel, int schoolId)
        {
                //The default when registering should mean that the user is an Admin for the school
            if (userLevel == "")
                userLevel = "Admin";

            UserModel data = new UserModel
            {
                UserID = 0,
                UserFname = firstName,
                UserLname = lastName,
                UserPhonNum = phoneNumber,
                UserEmail = email,
                UserLevel = userLevel,
                SchoolID = schoolId
            };

            string sql = @"INSERT INTO dbo.USER_INFO (UserID, UserFname, UserLname, UserPhonNum, UserEmail, UserLevel, SchoolID) VALUES (@UserID, @UserFname, @UserLname, @UserPhonNum, @UserEmail, @UserLevel, @SchoolID)";

            return sqlDataAccess.SaveData(sql, data);

        }
        public static List<int> CheckForDuplicates(string firstName, string lastName, string phoneNumber, string email, string userLevel)
        {
            if (userLevel == "")
                userLevel = "Admin";

            string sql = "SELECT COUNT(*) FROM dbo.SCHOOL WHERE UserFname = \'" + firstName + "\' AND UserLname = \'" + lastName + "\' AND UserPhonNum = \'" + phoneNumber + "\' AND UserEmail = \'" + email + "\' AND UserLevel = \'" + userLevel + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
    }
}
