using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class DiscussionReplyModel
    {
        public int DiscussionReplyID { get; set; }
        public string DiscussionReplyDesc { get; set; }
        public DateTime DiscussionReplyDate { get; set; }
        public int DiscussionID { get; set; }
        public int UserID { get; set; }
    }
}
