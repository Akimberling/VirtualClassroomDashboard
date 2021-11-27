using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
    public class DiscussionsModel
    {
        public int DiscussionID { get; set; }
        public string DiscussionTitle { get; set; }
        public string DiscussionDesc { get; set; }
        public DateTime DiscussionDate { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
    }
}
