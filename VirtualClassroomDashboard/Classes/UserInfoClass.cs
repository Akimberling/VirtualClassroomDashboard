using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroomDashboard.Models;
using VirtualClassroomDashboard.BusinessLogic;

namespace VirtualClassroomDashboard.Classes
{
    public class UserInfoClass
    {
            //user id
        private static int UID;
            //first name
        private static string FN;
            //last name
        private static string LN;
            //Phone Number
        private static string PN;
            //email
        private static string EM;
            //usertype
        private static string UT;
            //school id
        private static int SID;
            //school name
        private static string SN;
            //school city
        private static string SC;
            //school state
        private static string SS;

        public static void setUserData(UserModel userInfo)
        {

            UID = userInfo.UserID;
            FN  = userInfo.FirstName;
            LN  = userInfo.LastName;
            PN  = userInfo.PhoneNumber;
            EM  = userInfo.EmailAddress;
            UT  = userInfo.UserType;
            SID = userInfo.SchoolID;
            SN = userInfo.SchoolName;
            SC = userInfo.SchoolCity;
            SS = userInfo.SchoolState;
        }
        public static Dictionary<string, string> getUserData()
        {
                //basic user info
            Dictionary<string, string> BUI = new Dictionary<string, string>();

            BUI.Add("UserID", UID.ToString());
            BUI.Add("FirstName", FN);
            BUI.Add("LastName", LN);
            BUI.Add("PhoneNumber", PN);
            BUI.Add("EmailAddress", EM);
            BUI.Add("UserType", UT);
            BUI.Add("SchoolID", SID.ToString());

            return BUI;
        }

    }
}
