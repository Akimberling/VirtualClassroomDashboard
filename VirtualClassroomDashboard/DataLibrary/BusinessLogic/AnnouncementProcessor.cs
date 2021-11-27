using System.Collections.Generic;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;

namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class AnnouncementProcessor
    {
        public static int CreateAnnouncement(string Atitle, string Adesc, int cid, int uid, int fileID)
        {
            AnnouncementModelData data = new AnnouncementModelData
            { 
                AnnounceID = 0,
                AnnounceTitle = Atitle,
                AnnounceDesc = Adesc,
                CourseID = cid,
                UserID = uid,
                FileID = fileID
            };

            string sql = @"INSERT INTO dbo.ANNOUNCEMENTS (AnnounceID, AnnounceTitle, AnnounceDesc, CourseID, UserID, FileID) VALUES (@AnnounceID, @AnnounceTitle, @AnnounceDesc, @CourseID, @UserID, @FileID);";

            return sqlDataAccess.SaveData(sql, data);
        }
        //update the Announcement 
        public static int updateAnnouncement(int AID, string Atitle, string Adesc, int fileID)
        {
            AnnouncementModelData data = new AnnouncementModelData
            {
                AnnounceID = AID,
                AnnounceTitle = Atitle,
                AnnounceDesc = Adesc,
                FileID = fileID
            };

            string sql = @"UPDATE dbo.ANNOUNCEMENTS SET AnnounceTitle = @AnnounceTitle, AnnounceDesc = @AnnounceDesc, FileID = @FileID WHERE AnnounceID = @AnnounceID;";

            return sqlDataAccess.SaveData(sql, data);
        }
        //delete an announcement
        public static int deleteAnnouncement(int AID)
        {
            AnnouncementModelData data = new AnnouncementModelData
            {
                AnnounceID = AID
            };

            string sql = @"DELETE FROM dbo.ANNOUNCEMENTS WHERE AnnounceID = @AnnounceID;";

            return sqlDataAccess.SaveData(sql, data);
        }
        //retrieve Announcement
        public static List<AnnouncementModelData> RetrieveAnnouncement(int AID)
        {
            AnnouncementModelData data = new AnnouncementModelData
            {
                AnnounceID = AID
            };

            string sql = @"SELECT * FROM dbo.ANNOUNCEMENTS WHERE AnnounceID = @AnnounceID;";

            return sqlDataAccess.LoadData<AnnouncementModelData>(sql);
        }
        //retrieve all the announcements for a course
        public static List<AnnouncementModelData> RetrieveAllCourseAnnouncements(int cid, int uid)
        {
            AnnouncementModelData data = new AnnouncementModelData
            {
                CourseID = cid,
                UserID = uid
            };

            string sql = @"SELECT * FROM dbo.COURSE_FILES WHERE CourseID = @CourseID AND UserID = @UserID;";

            return sqlDataAccess.LoadData<AnnouncementModelData>(sql);
        }
    }
}
