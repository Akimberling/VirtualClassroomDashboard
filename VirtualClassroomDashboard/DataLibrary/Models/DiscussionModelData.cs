using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.DataLibrary.Models
{
    public class DiscussionModelData
    {
        public int DiscussionID { get; set; }
        public string DiscussionTitle { get; set; }
        public string DiscussionDesc { get; set; }
        public DateTime DiscussionDate { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }

    }
}
