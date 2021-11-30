using VirtualClassroomDashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;


namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class DiscussionProcessor
    {
        public static int CreateDiscussion(int UID, int CID, string DiscussionTitle, string DiscussionDescription, DateTime Ddate)
        {
            DiscussionModelData data = new DiscussionModelData
            {
                DiscussionID = 0,
                DiscussionTitle = DiscussionTitle,
                DiscussionDesc = DiscussionDescription,
                DiscussionDate = Ddate,
                CourseID = CID,
                UserID = UID
            };

            string sql = @"INSERT INTO dbo.DISCUSSION (DiscussionID, DiscussionTitle, DiscussionDesc, DiscussionDate, CourseID, UserID) VALUES (@DiscussionID, @DiscussionTitle, @DiscussionDesc, @DiscussionDate, @CourseID, @UserID);";

            return sqlDataAccess.SaveData(sql, data);

        }
    }
}
