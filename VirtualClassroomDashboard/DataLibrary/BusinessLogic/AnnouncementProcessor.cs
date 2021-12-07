using System.Collections.Generic;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;

namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class AnnouncementProcessor
    {
        public static int CreateAnnouncement(string Atitle, string Adesc, int cid, int uid, int fileID)
        {
            string sql;
            AnnouncementModelData data = new AnnouncementModelData
            { 
                AnnounceID = 0,
                AnnounceTitle = Atitle,
                AnnounceDesc = Adesc,
                CourseID = cid,
                UserID = uid,
                FileID = fileID
            };
            if (fileID == 0)
            {
                sql = @"INSERT INTO dbo.ANNOUNCEMENTS (AnnounceID, AnnounceTitle, AnnounceDesc, CourseID, UserID, FileID) VALUES (@AnnounceID, @AnnounceTitle, @AnnounceDesc, @CourseID, @UserID, NULL);";
            }
            else
            {
                sql = @"INSERT INTO dbo.ANNOUNCEMENTS (AnnounceID, AnnounceTitle, AnnounceDesc, CourseID, UserID, FileID) VALUES (@AnnounceID, @AnnounceTitle, @AnnounceDesc, @CourseID, @UserID, @FileID);";
            }

            return sqlDataAccess.SaveData(sql, data);
        }
        //delete an announcement
        public static int deleteAnnouncement(int AID)
        {
            AnnouncementModelData data = new AnnouncementModelData
            {
                AnnounceID = AID
            };

            string sql = "DELETE FROM dbo.ANNOUNCEMENTS WHERE AnnounceID = \'" + AID + "\';";

            return sqlDataAccess.SaveData(sql, data);
        }
        //retrieve Announcement
        public static List<AnnouncementModelData> RetrieveAnnouncement(int AID)
        {

            string sql = "SELECT * FROM dbo.ANNOUNCEMENTS WHERE AnnounceID = \'" + AID + "\';";

            return sqlDataAccess.LoadData<AnnouncementModelData>(sql);
        }
        //retrieve all the announcements for a course
        public static List<AnnouncementModelData> RetrieveAllCourseAnnouncements(int cid)
        {
            string sql = "SELECT * FROM dbo.ANNOUNCEMENTS WHERE CourseID = \'" + cid + "\';";

            return sqlDataAccess.LoadData<AnnouncementModelData>(sql);
        }
    }
}
