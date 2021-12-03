using System;
using System.Collections.Generic;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;

namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class DiscussionReplyProcessor
    {
        public static int CreateDiscussionReply(int UID, int DID, string DiscussionDescription, string Ddate)
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
        public static List<DiscussionReplyModelData> RetrieveDiscussionRepliesForCourse(int DID)
        {
            string sql = "SELECT dbo.DISCUSSION_REPLY.DiscussionReplyID, dbo.DISCUSSION_REPLY.DiscussionReplyDesc, dbo.DISCUSSION_REPLY.DiscussionReplyDate, dbo.DISCUSSION_REPLY.UserID, dbo.USER_INFO.UserFname + dbo.USER_INFO.UserLname as UserName FROM dbo.DISCUSSION_REPLY INNER JOIN dbo.USER_INFO ON dbo.DISCUSSION_REPLY.UserID = dbo.USER_INFO.UserID WHERE dbo.DISCUSSION_REPLY.DiscussionID = \'" + DID + "\'; ";

            return sqlDataAccess.LoadData<DiscussionReplyModelData>(sql);
        }
        public static int deleteUserFromDiscussionReply(int DID, int uid)
        {
            DiscussionReplyModelData data = new DiscussionReplyModelData
            {
                DiscussionID = DID,
                UserID = uid
            };
            string sql = "DELETE FROM dbo.DISCUSSION_REPLY WHERE DiscussionID = @DiscussionID AND UserID = @UserID;";

            return sqlDataAccess.SaveData(sql, data);
        }
    }
}