using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.DataLibrary.Models
{
    public class DiscussionReplyModelData
    {
        public int DiscussionReplyID { get; set; }
        public string DiscussionReplyDesc { get; set; }
        public DateTime DiscussionReplyDate { get; set; }
        public int DiscussionID { get; set; }
        public int UserID { get; set; }
    }
}
