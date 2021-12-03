using System;

namespace VirtualClassroomDashboard.DataLibrary.Models
{
    public class DiscussionReplyModelData
    {
        public int DiscussionReplyID { get; set; }
        public string DiscussionReplyDesc { get; set; }
        public String DiscussionReplyDate { get; set; }
        public int DiscussionID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
