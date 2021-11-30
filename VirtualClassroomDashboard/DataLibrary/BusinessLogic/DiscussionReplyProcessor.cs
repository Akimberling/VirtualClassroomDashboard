using VirtualClassroomDashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;

namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class DiscussionReplyProcessor
    {
        public static int CreateDiscussion(int UID, int DID, string DiscussionDescription, DateTime Ddate)
        {
            DiscussionReplyModelData data = new DiscussionReplyModelData
            {
                DiscussionReplyID = 0,
                DiscussionReplyDesc = DiscussionDescription,
                DiscussionReplyDate = Ddate,
                DiscussionID = DID,
                UserID = UID
            };

            string sql = @"INSERT INTO dbo.DISCUSSION_REPLY (DiscussionReplyID, DiscussionReplyDesc, DiscussionReplyDate, DiscussionID, UserID) VALUES (@DiscussionReplyID, @DiscussionReplyDesc, @DiscussionReplyDate, @DiscussionID, @UserID);";

            return sqlDataAccess.SaveData(sql, data);

        }
    }
}