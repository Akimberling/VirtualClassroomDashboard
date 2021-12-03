using System;
using System.Collections.Generic;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;


namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class DiscussionProcessor
    {
        public static int CreateDiscussion(int UID, int CID, string DiscussionTitle, string DiscussionDescription, String Ddate)
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
        public static List<DiscussionModelData> RetrieveDiscussionsForCourse(int CID)
        {
            string sql = "SELECT * FROM dbo.DISCUSSION WHERE CourseID = \'" + CID + "\';";

            return sqlDataAccess.LoadData<DiscussionModelData>(sql);
        }
        public static List<DiscussionModelData> RetrieveDiscussionForCourse(int DID)
        {
            string sql = "SELECT * FROM dbo.DISCUSSION WHERE CourseID = \'" + DID + "\';";

            return sqlDataAccess.LoadData<DiscussionModelData>(sql);
        }
        public static int deleteDiscussions(int DID)
        {
             DiscussionModelData data = new DiscussionModelData
            {
                DiscussionID = DID
            };
            string sql = "DELETE FROM dbo.DISCUSSION WHERE DiscussionID = @DiscussionID;";

            return sqlDataAccess.SaveData(sql, data);
        }
    }
}
