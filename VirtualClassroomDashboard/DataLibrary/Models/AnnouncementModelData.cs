﻿
namespace VirtualClassroomDashboard.DataLibrary.Models
{
    public class AnnouncementModelData
    {

            //generated by database
            public int AnnounceID { get; set; }

            //title of the announcement
            public string AnnounceTitle { get; set; }

            //the content of the announcement
            public string AnnounceDesc { get; set; }

            //user (Teacher) and the course the announcement is for
            public int CourseID { get; set; }

            public int UserID { get; set; }

            public int FileID { get; set; }
    }
}

