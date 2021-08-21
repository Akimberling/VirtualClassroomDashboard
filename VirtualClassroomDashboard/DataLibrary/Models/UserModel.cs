using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualClassroomDashboard.Models
{
    public class UserModelData
    {
        public int UserID { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string UserPhonNum { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserSalt { get; set; }
        public string UserType { get; set; }
        public int SchoolID { get; set; }


    }
}
